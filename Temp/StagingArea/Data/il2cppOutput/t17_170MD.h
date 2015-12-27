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

struct t17_170;
struct t1_1;

#include "codegen/il2cpp-codegen.h"

extern "C" void m17_604_gshared (t17_170 * __this, const MethodInfo* method);
#define m17_604(__this, method) (( void (*) (t17_170 *, const MethodInfo*))m17_604_gshared)(__this, method)
extern "C" void m17_605_gshared (t17_170 * __this, t1_1 * p0, t1_1 * p1, const MethodInfo* method);
#define m17_605(__this, p0, p1, method) (( void (*) (t17_170 *, t1_1 *, t1_1 *, const MethodInfo*))m17_605_gshared)(__this, p0, p1, method)
extern "C" t1_1 * m17_606_gshared (t17_170 * __this, const MethodInfo* method);
#define m17_606(__this, method) (( t1_1 * (*) (t17_170 *, const MethodInfo*))m17_606_gshared)(__this, method)
extern "C" bool m17_607_gshared (t17_170 * __this, const MethodInfo* method);
#define m17_607(__this, method) (( bool (*) (t17_170 *, const MethodInfo*))m17_607_gshared)(__this, method)
