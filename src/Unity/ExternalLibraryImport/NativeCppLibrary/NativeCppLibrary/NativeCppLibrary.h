#ifdef NATIVECPPLIBRARY_EXPORTS
#define NATIVECPPLIBRARY_API __declspec(dllexport)
#endif

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