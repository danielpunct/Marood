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

struct t8_82;
struct t1_1;
struct t1_35;
struct t1_36;

#include "codegen/il2cpp-codegen.h"
#include "t1_24.h"

extern "C" void m8_319_gshared (t8_82 * __this, t1_1 * p0, t1_24 p1, const MethodInfo* method);
#define m8_319(__this, p0, p1, method) (( void (*) (t8_82 *, t1_1 *, t1_24, const MethodInfo*))m8_319_gshared)(__this, p0, p1, method)
extern "C" double m8_321_gshared (t8_82 * __this, t1_1 * p0, t1_1 * p1, const MethodInfo* method);
#define m8_321(__this, p0, p1, method) (( double (*) (t8_82 *, t1_1 *, t1_1 *, const MethodInfo*))m8_321_gshared)(__this, p0, p1, method)
extern "C" t1_1 * m8_323_gshared (t8_82 * __this, t1_1 * p0, t1_1 * p1, t1_36 * p2, t1_1 * p3, const MethodInfo* method);
#define m8_323(__this, p0, p1, p2, p3, method) (( t1_1 * (*) (t8_82 *, t1_1 *, t1_1 *, t1_36 *, t1_1 *, const MethodInfo*))m8_323_gshared)(__this, p0, p1, p2, p3, method)
extern "C" double m8_325_gshared (t8_82 * __this, t1_1 * p0, const MethodInfo* method);
#define m8_325(__this, p0, method) (( double (*) (t8_82 *, t1_1 *, const MethodInfo*))m8_325_gshared)(__this, p0, method)
