class Integral
{
private:
	autoList<uchar> *Figures;
	int LZero;

public:
	Integral()
	{
		this->Figures = new autoList<uchar>();
		this->LZero = 0;
	}
	Integral(const Integral &source)
	{
		error();
	}
	~Integral()
	{
		delete this->Figures;
	}

	void Clear()
	{
		this->Figures->Clear();
		this->LZero = 0;
	}
	int GetCount()
	{
		return this->LZero + this->Figures->GetCount();
	}
	void Reverse()
	{
		this->Figures->Reverse();

		for(int c = 0; c < this->LZero; c++)
			this->Figures->AddElement(0);

		this->LZero = 0;
	}

	void PutFigure(int index, int value)
	{
		if(this->LZero)
		{
			this->Figures->InsertRepeatToStart(0, this->LZero);
			this->LZero = 0;
		}
		this->Figures->PutElement(index, value, 0);
	}
	int RefFigure(int index)
	{
		if(index < this->LZero)
			return 0;

		return this->Figures->RefElement(index - this->LZero, 0);
	}

	void ShiftZero(int count)
	{
		this->LZero += count;
//		this->Figures->InsertRepeatToStart(0, count); // old
	}
	void UnshiftZero(int count)
	{
		if(this->LZero < count)
		{
			count -= this->LZero;
			this->LZero = 0;
			this->Figures->RemoveElementsFromStart(count);
		}
		else
			this->LZero -= count;
	}
	void RemoveTrailZero()
	{
		this->Figures->UnaddRepeat(0);
	}
};

class Rational
{
private:
	void Init()
	{
		this->Figures = new Integral();
		this->DecPos = 0;
		this->Sign = 1;
	}

public:
	Integral *Figures;
	int DecPos;
	int Sign; // 1 or -1, "0" -> 1

	Rational()
	{
		this->Init();
	}
	Rational(char *operand)
	{
		this->Init();
		this->SetString(operand);
	}
	Rational(int value)
	{
		this->Init();
		this->AddInt(value);
	}
	Rational(const Rational &source)
	{
		error();
	}
	~Rational()
	{
		delete this->Figures;
	}

	void CheckFigures()
	{
		for(int index = 0; index < this->Figures->GetCount(); index++)
		{
			int value = this->Figures->RefFigure(index);

			errorCase_m(!m_isRange(value, 0, Radix - 1), "進数以上の数字が記述されています。");
		}
	}
	void Normalize()
	{
#if 1
		// "123.000" -> "123"
		{
			int unscnt = 0;

			while(unscnt < this->Figures->GetCount() && this->Figures->RefFigure(unscnt) == 0)
				unscnt++;

			m_minim(unscnt, this->DecPos);

			this->Figures->UnshiftZero(unscnt);
			this->DecPos -= unscnt;
		}
#else // OLD
		while(0 < this->Figures->GetCount() && this->Figures->RefFigure(0) == 0 && 0 < this->DecPos) // "123.000" -> "123"
		{
			this->Figures->UnshiftZero(1);
			this->DecPos--;
		}
#endif
		this->Figures->RemoveTrailZero(); // "000123" -> "123"

		if(this->Figures->GetCount() == 0) // ? "0"
		{
			this->DecPos = 0;
			this->Sign = 1;
		}
	}

	void AddInt(int value, int index = 0)
	{
		while(value)
		{
			value += this->Figures->RefFigure(index);
			this->Figures->PutFigure(index, value % Radix);
			index++;
			value /= Radix;
		}
	}
	void SlideDecPos(int count)
	{
		this->Figures->ShiftZero(count);
		this->DecPos += count;
	}

	void Reset()
	{
		this->Figures->Clear();
		this->DecPos = 0;
		this->Sign = 1;
	}
	void SetString(char *operand)
	{
		this->Reset();

		int periodFlag = 0;
		int addPos = 0;

		for(char *p = operand; *p; p++)
		{
			int d = *p;

			if(d == '-')
			{
				errorCase_m(this->Sign == -1, "複数の負符号が記述されています。");

				this->Sign = -1;
				continue;
			}
			if(d == '.')
			{
				errorCase_m(periodFlag, "複数の小数点が記述されています。");

				periodFlag = 1;
				continue;
			}

			if(m_isDigit(d))
			{
				d -= '0';
			}
			else if(m_isAlpha(d))
			{
				d = toLower(d) - 'a' + 10;
			}
			else if(KANA_A <= d && d <= KANA_N)
			{
				d = d - KANA_A + 36;
			}
			else
			{
				error_m("不明な数字が記述されています。");
			}
			this->Figures->PutFigure(addPos++, d);

			if(periodFlag)
				this->DecPos++;
		}
		this->Figures->Reverse();
		this->CheckFigures();
		this->Normalize();
	}
	char *ToString()
	{
		this->CheckFigures();
		this->Normalize();

		char *buffer = strx("");

		if(this->Sign == -1)
			buffer = addChar(buffer, '-');

		for(int index = m_max(this->DecPos, this->Figures->GetCount() - 1); ; index--)
		{
			int d = this->Figures->RefFigure(index);

			if(d < 10)
				buffer = addChar(buffer, d + '0');
			else if(d < 36)
				buffer = addChar(buffer, d - 10 + 'a');
			else
				buffer = addChar(buffer, d - 36 + KANA_A);

			if(index <= 0)
				break;

			if(index == this->DecPos)
				buffer = addChar(buffer, '.');
		}
		return buffer;
	}
	int ToInt()
	{
		errorCase(0 < this->DecPos);

		__int64 value = 0;

		for(int index = this->Figures->GetCount() - 1; 0 <= index; index--)
		{
			value *= Radix;
			value += this->Figures->RefFigure(index);

			errorCase(INT_MAX < value);
		}
		return (int)value * this->Sign;
	}
};
