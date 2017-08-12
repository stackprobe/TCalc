int getZero(void);
__int64 s2i64(char *line);
__int64 s2i64_x(char *line);
int s2i(char *line);
int s2i_x(char *line);

int compInt(int a, int b);
int compI2D(i2D_t a, i2D_t b);

int isHitKey(int key);

void addValue(autoList<uchar> *block, uint64 value);
uint64 unaddValue64(autoList<uchar> *block);

char *incrementColumnDigits(char *column, char *digits);
char *incrementPathDigits(char *path, char *digits);
char *incrementColumn(char *column);
char *incrementPath(char *path);
char *toCreatablePath(char *path, int errorThreshold);

char *getDateTimeStamp(time_t t);
char *thousandComma(char *line);
char *makeJStamp(char *eStamp);
char *makeJStamp_x(char *eStamp);

template <class Element_t>
int getIndex(autoList<Element_t> *list, Element_t e, int (*compFunc)(Element_t, Element_t))
{
	for(int index = 0; index < list->GetCount(); index++)
		if(!compFunc(e, list->GetElement(index)))
			return index;

	return -1; // not found
}

template <class Deletable_t>
void callDelete(Deletable_t *i)
{
	delete i;
}

template <class Deletable_t>
void deleteList(autoList<Deletable_t> *list)
{
	list->CallAllElement(callDelete);
	delete list;
}
