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

struct t17_168;
struct t1_1;

#include "codegen/il2cpp-codegen.h"

extern "C" void m17_600_gshared (t17_168 * __this, const MethodInfo* method);
#define m17_600(__this, method) (( void (*) (t17_168 *, const MethodInfo*))m17_600_gshared)(__this, method)
extern "C" void m17_601_gshared (t17_168 * __this, double p0, t1_1 * p1, const MethodInfo* method);
#define m17_601(__this, p0, p1, method) (( void (*) (t17_168 *, double, t1_1 *, const MethodInfo*))m17_601_gshared)(__this, p0, p1, method)
extern "C" t1_1 * m17_602_gshared (t17_168 * __this, const MethodInfo* method);
#define m17_602(__this, method) (( t1_1 * (*) (t17_168 *, const MethodInfo*))m17_602_gshared)(__this, method)
extern "C" bool m17_603_gshared (t17_168 * __this, const MethodInfo* method);
#define m17_603(__this, method) (( bool (*) (t17_168 *, const MethodInfo*))m17_603_gshared)(__this, method)
