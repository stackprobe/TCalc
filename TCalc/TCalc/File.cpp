#include "all.h"

int existPath(char *path)
{
	return !m_isEmpty(path) && !_access(path, 0);
}
int existFile(char *file)
{
	return existPath(file) && !(GetFileAttributes(file) & FILE_ATTRIBUTE_DIRECTORY);
}
int existDir(char *dir)
{
	return existPath(dir) && GetFileAttributes(dir) & FILE_ATTRIBUTE_DIRECTORY;
}

void trimPath(char *path)
{
	escapeYen(path);
	trimSequ(path, '/');
	unescapeYen(path);
}
char *combine(char *dir, char *file)
{
	if(dir[0] && dir[1] == ':' && dir[2] == '\0')
	{
		static char buff[] = "?:.";

		buff[0] = dir[0];
		dir = buff;
	}
	char *dirFile = xcout("%s\\%s", dir, file);

	trimPath(dirFile);
	return dirFile;
}
char *combine_cx(char *dir, char *file)
{
	char *out = combine(dir, file);
	memFree(file);
	return out;
}
char *combine_xc(char *dir, char *file)
{
	char *out = combine(dir, file);
	memFree(dir);
	return out;
}
char *getDir(char *path)
{
	path = strx(path);
	escapeYen(path);
	char *p = strrchr(path, '/');

	if(p)
	{
		*p = '\0';
		unescapeYen(path);

		// ? ルートディレクトリ
		if(
			path[0] &&
			path[1] == ':' &&
			path[2] == '\0'
			)
		{
			path[2] = '\\';
			path[3] = '\0';
		}
	}
	else
		strz(path, ".");

	return path;
}
char *getDir_x(char *path)
{
	char *out = getDir(path);
	memFree(path);
	return out;
}
char *getLocalPath(char *path)
{
	path = strx(path);
	escapeYen(path);
	char *p = strrchr(path, '/');

	if(p)
	{
		p = strx(p + 1);
		memFree(path);
		path = p;
	}
	return path;
}
char *getLocalPath_x(char *path)
{
	char *out = getLocalPath(path);
	memFree(path);
	return out;
}

void setCwd(char *dir)
{
	errorCase(m_isEmpty(dir));
	errorCase(_chdir(dir)); // ? 失敗
}
void setCwd_x(char *dir)
{
	setCwd(dir);
	memFree(dir);
}
char *getCwd(void)
{
	char *dirBuff = _getcwd(NULL, 0);
	errorCase(m_isEmpty(dirBuff));
	char *dir = strx(dirBuff);
	free(dirBuff);
	return dir;
}
static oneObject(autoList<char *>, new autoList<char *>(), GetCwdStack)

void addCwd(char *dir)
{
	GetCwdStack()->AddElement(getCwd());
	setCwd(dir);
}
void addCwd_x(char *dir)
{
	addCwd(dir);
	memFree(dir);
}
void unaddCwd(void)
{
	setCwd_x(GetCwdStack()->UnaddElement());
}

#if 0 // not using
void createFile(char *file)
{
	errorCase(m_isEmpty(file));
	fileClose(fileOpen(file, "wb"));
}
void createDir(char *dir)
{
	errorCase(m_isEmpty(dir));
	errorCase(My_mkdir(dir)); // ? 失敗
}
#endif

void removeFile(char *file)
{
	errorCase(m_isEmpty(file));
	remove(file);
}
void removeDir(char *dir)
{
	errorCase(m_isEmpty(dir));
	_rmdir(dir);
}
void clearDir(char *dir)
{
	autoList<char *> *paths = lss(dir);

	while(paths->GetCount())
	{
		char *path = paths->UnaddElement();

		remove(path);
		_rmdir(path);

		memFree(path);
	}
	delete paths;
}
void forceRemoveDir(char *dir)
{
	clearDir(dir);
	_rmdir(dir);
}

void fileMove(char *rFile, char *wFile)
{
	errorCase(rename(rFile, wFile)); // ? 失敗
}
void fileCopy(char *rFile, char *wFile)
{
	remove(wFile); // anti rFile == wFile

	__int64 rCount = getFileSize(rFile);

	FILE *rfp = fileOpen(rFile, "rb");
	FILE *wfp = fileOpen(wFile, "wb");

	const int buffSize = 1000000;
	uchar *buff = (uchar *)memAlloc(buffSize);

	while(0 < rCount)
	{
		int rSize = (int)m_min(rCount, buffSize);

		fileRead(rfp, buff, rSize);
		fileWrite(wfp, buff, rSize);

		rCount -= rSize;
	}
	memFree(buff);

	fileClose(rfp);
	fileClose(wfp);
}

char *getFullPath(char *path, char *baseDir)
{
	errorCase(m_isEmpty(path));
	errorCase(m_isEmpty(baseDir));

	addCwd(baseDir);
	path = _fullpath(NULL, path, 0);
	unaddCwd();

	char *retPath = strx(path);
	free(path);
	return retPath;
}
char *getFullPath_xc(char *path, char *baseDir)
{
	char *out = getFullPath(path, baseDir);
	memFree(path);
	return out;
}
static char *GetExtPeriod(char *path)
{
	char *p = strrchr(path, '.');

	if(!p || findMbsChar(p + 1, '\\'))
		return NULL;

	return p;
}
char *getExt(char *path)
{
	char *p = GetExtPeriod(path);

	if(p)
		p++;
	else
		p = strchr(path, '\0');

	return p;
}
int removeExt(char *path) // ret: ? removed
{
	char *p = GetExtPeriod(path);

	if(p)
	{
		*p = '\0';
		return 1;
	}
	return 0;
}
char *addExt(char *path, char *ext) // ret: strr(path)
{
	return addToken_x(path, xcout(".%s", ext));
}

static int IsWindowsReserveNode(char *node)
{
	if(!_stricmp(node, "AUX")) return 1;
	if(!_stricmp(node, "CON")) return 1;
	if(!_stricmp(node, "NUL")) return 1;
	if(!_stricmp(node, "PRN")) return 1;

	if(
		!mbs_stricmp(node, "COM", 3) ||
		!mbs_stricmp(node, "LPT", 3)
		)
		if(
			'1' <= node[3] && node[3] <= '9' &&
			node[4] == '\0'
			)
			return 1;

	// グレーゾーン {
	if(!_stricmp(node, "CLOCK$")) return 1;
	if(!_stricmp(node, "COM0")) return 1;
	if(!_stricmp(node, "LPT0")) return 1;
	// }

	return 0;
}
static int IsPathChar(int chr)
{
	if(
		'\x20' <= chr && chr <= '\x7e' ||
		'\xa1' <= chr && chr <= '\xdf'
		)
		if(!strchr("\"*/:<>?\\|", chr)) return 1;

	return 0;
}
char *makeFairLocalPath(char *localPath)
{
	autoList<char *> *nodes = tokenize(localPath, ".");

	for(int index = 0; index < nodes->GetCount(); index++)
	{
		char *node = nodes->GetElement(index);

		for(char *p = node; *p; p++)
		{
			if(_ismbblead(p[0]) && _ismbbtrail(p[1])) // HACK
//			if(isJChar(p))
			{
				p++;
			}
			else if(IsPathChar(*p))
			{
				1; // noop
			}
			else
			{
				*p = '#'; // 不正な文字の代わり
			}
		}
		trimEdge(node, ' ');

		if(IsWindowsReserveNode(node))
		{
			node[0] = '\0';
		}
		if(!node[0])
		{
			strz(node, "$_");
		}
		nodes->SetElement(index, node);
	}
	return untokenize(nodes, ".");
}
char *makeFairLocalPath_x(char *localPath)
{
	char *out = makeFairLocalPath(localPath);
	memFree(localPath);
	return out;
}
