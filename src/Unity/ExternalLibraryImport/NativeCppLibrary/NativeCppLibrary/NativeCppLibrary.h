#ifdef NATIVECPPLIBRARY_EXPORTS
#define NATIVECPPLIBRARY_API __declspec(dllexport)
#else
#define NATIVECPPLIBRARY_API __declspec(dllimport)
#endif

// 這個類別是從 dll 匯出的
class NATIVECPPLIBRARY_API NativeCppLibrary {
public:
	NativeCppLibrary() = default;
};

extern "C"
{
	NATIVECPPLIBRARY_API int displayNumber();
	NATIVECPPLIBRARY_API int getRandom();
	NATIVECPPLIBRARY_API int displaySum();
}