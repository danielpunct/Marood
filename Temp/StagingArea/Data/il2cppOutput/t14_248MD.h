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

struct t14_248;
struct t14_5;
struct t14_5_marshaled;
struct t1_29;
struct t1_336;

#include "codegen/il2cpp-codegen.h"

extern "C" void m14_1395_gshared (t14_248 * __this, t14_5 * p0, t1_29 * p1, bool p2, const MethodInfo* method);
#define m14_1395(__this, p0, p1, p2, method) (( void (*) (t14_248 *, t14_5 *, t1_29 *, bool, const MethodInfo*))m14_1395_gshared)(__this, p0, p1, p2, method)
extern "C" void m14_1536_gshared (t14_248 * __this, t1_336* p0, const MethodInfo* method);
#define m14_1536(__this, p0, method) (( void (*) (t14_248 *, t1_336*, const MethodInfo*))m14_1536_gshared)(__this, p0, method)
