#ifdef NATIVECPPLIBRARY_EXPORTS
#define NATIVECPPLIBRARY_API __declspec(dllexport)
#endif

extern "C"
{
	NATIVECPPLIBRARY_API int displayNumber();
	NATIVECPPLIBRARY_API int getRandom();
	NATIVECPPLIBRARY_API int displaySum();

	class NATIVECPPLIBRARY_API NativeCppLibrary {
	public:
		NativeCppLibrary() = default;
		int sum(int a, int b);
	};
}