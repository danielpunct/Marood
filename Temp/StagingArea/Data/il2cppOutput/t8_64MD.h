#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>
#include <assert.h>
#include <exception>

struct t8_64;
struct t1_1;
struct t1_35;
struct t1_36;

#include "codegen/il2cpp-codegen.h"
#include "t1_24.h"

extern "C" void m8_207_gshared (t8_64 * __this, t1_1 * p0, t1_24 p1, const MethodInfo* method);
#define m8_207(__this, p0, p1, method) (( void (*) (t8_64 *, t1_1 *, t1_24, const MethodInfo*))m8_207_gshared)(__this, p0, p1, method)
extern "C" t1_1 * m8_208_gshared (t8_64 * __this, t1_1 * p0, t1_1 * p1, const MethodInfo* method);
#define m8_208(__this, p0, p1, method) (( t1_1 * (*) (t8_64 *, t1_1 *, t1_1 *, const MethodInfo*))m8_208_gshared)(__this, p0, p1, method)
extern "C" t1_1 * m8_209_gshared (t8_64 * __this, t1_1 * p0, t1_1 * p1, t1_36 * p2, t1_1 * p3, const MethodInfo* method);
#define m8_209(__this, p0, p1, p2, p3, method) (( t1_1 * (*) (t8_64 *, t1_1 *, t1_1 *, t1_36 *, t1_1 *, const MethodInfo*))m8_209_gshared)(__this, p0, p1, p2, p3, method)
extern "C" t1_1 * m8_210_gshared (t8_64 * __this, t1_1 * p0, const MethodInfo* method);
#define m8_210(__this, p0, method) (( t1_1 * (*) (t8_64 *, t1_1 *, const MethodInfo*))m8_210_gshared)(__this, p0, method)
