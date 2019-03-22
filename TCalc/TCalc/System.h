extern int BatchMode;
extern int SilentMode;

void addFinalizer(void (*func)(void));
void (*unaddFinalizer(void))(void);

void termination(int errorlevel);
void error2(char *source, int lineno, char *function, char *message = NULL);

#define error() \
	error2(__FILE__, __LINE__, __FUNCTION__)

#define error_m(message) \
	error2(__FILE__, __LINE__, __FUNCTION__, (message))

#define errorCase(status) \
	do { \
	if((status)) error(); \
	} while(0)

#define errorCase_m(status, message) \
	do { \
	if((status)) error_m((message)); \
	} while(0)

#define LOGPOS() \
	cout("%s (%d) %s\n", __FILE__, __LINE__, __FUNCTION__)

// sync > @ cout_h
void cout(char *format, ...);
char *xcout(char *format, ...);
char *vxcout(char *format, va_list marker);
void coutLongText(char *text);
void coutLongText_x(char *text);
// < sync

int hasArgs(int count);
int argIs(char *spell);
char *getArg(int index);
char *nextArg(void);
int getArgIndex(void);
void setArgIndex(int index);
char *getTrailArgs(void);

char *getSelfFile(void);
char *getSelfDir(void);

char *getTempRtDir(void);
char *makeTempPath(char *suffix = ".tmp");
#if 0 // not using
char *makeTempFile(char *suffix = ".tmp");
char *makeTempDir(char *suffix = ".tmp");
#endif

time_t now(void);
char *getTimeStamp(time_t t = 0);
