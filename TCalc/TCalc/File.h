int existPath(char *path);
int existFile(char *file);
int existDir(char *dir);

void trimPath(char *path);
char *combine(char *dir, char *file);
char *combine_cx(char *dir, char *file);
char *combine_xc(char *dir, char *file);
char *getDir(char *path);
char *getDir_x(char *path);
char *getLocalPath(char *path);
char *getLocalPath_x(char *path);

void setCwd(char *dir);
void setCwd_x(char *dir);
char *getCwd(void);
void addCwd(char *dir);
void addCwd_x(char *dir);
void unaddCwd(void);

#if 0 // not using
void createFile(char *file);
void createDir(char *dir);
#endif

void removeFile(char *file);
void removeDir(char *dir);
void clearDir(char *dir);
void forceRemoveDir(char *dir);

void fileMove(char *rFile, char *wFile);
void fileCopy(char *rFile, char *wFile);

char *getFullPath(char *path, char *baseDir = ".");
char *getFullPath_xc(char *path, char *baseDir = ".");
char *getExt(char *path);
int removeExt(char *path);
char *addExt(char *path, char *ext);

char *makeFairLocalPath(char *localPath);
char *makeFairLocalPath_x(char *localPath);
