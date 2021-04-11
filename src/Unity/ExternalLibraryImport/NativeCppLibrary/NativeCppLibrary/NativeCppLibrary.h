// 下列 ifdef 區塊是建立巨集的標準方式，讓從 DLL 匯出的過程更簡單。
// 此 DLL 中的所有檔案均使用命令列中定義的 NATIVECPPLIBRARY_EXPORTS 來編譯。
// 此符號不應在其他使用此 DLL 的任何專案中定義
// 這樣一來，原始程式檔中包含此檔案的其他任何專案，
// 都會將 NATIVECPPLIBRARY_API 函式視為從 DLL 匯入，
// 而此 DLL 會將使用此巨集定義的符號視為匯出。
#ifdef NATIVECPPLIBRARY_EXPORTS
#define NATIVECPPLIBRARY_API __declspec(dllexport)
#else
#define NATIVECPPLIBRARY_API __declspec(dllimport)
#endif

// 這個類別是從 dll 匯出的
class NATIVECPPLIBRARY_API CNativeCppLibrary {
public:
	CNativeCppLibrary(void);
	// TODO: 在此新增您的方法。
};

extern NATIVECPPLIBRARY_API int nNativeCppLibrary;

NATIVECPPLIBRARY_API int fnNativeCppLibrary(void);

extern "C"
{
	NATIVECPPLIBRARY_API int displayNumber();
	NATIVECPPLIBRARY_API int getRandom();
	NATIVECPPLIBRARY_API int displaySum();
}