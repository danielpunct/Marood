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

struct t8_76;
struct t1_1;
struct t1_35;
struct t1_36;

#include "codegen/il2cpp-codegen.h"
#include "t1_24.h"

extern "C" void m8_278_gshared (t8_76 * __this, t1_1 * p0, t1_24 p1, const MethodInfo* method);
#define m8_278(__this, p0, p1, method) (( void (*) (t8_76 *, t1_1 *, t1_24, const MethodInfo*))m8_278_gshared)(__this, p0, p1, method)
extern "C" void m8_279_gshared (t8_76 * __this, t1_1 * p0, t1_1 * p1, const MethodInfo* method);
#define m8_279(__this, p0, p1, method) (( void (*) (t8_76 *, t1_1 *, t1_1 *, const MethodInfo*))m8_279_gshared)(__this, p0, p1, method)
extern "C" t1_1 * m8_280_gshared (t8_76 * __this, t1_1 * p0, t1_1 * p1, t1_36 * p2, t1_1 * p3, const MethodInfo* method);
#define m8_280(__this, p0, p1, p2, p3, method) (( t1_1 * (*) (t8_76 *, t1_1 *, t1_1 *, t1_36 *, t1_1 *, const MethodInfo*))m8_280_gshared)(__this, p0, p1, p2, p3, method)
extern "C" void m8_281_gshared (t8_76 * __this, t1_1 * p0, const MethodInfo* method);
#define m8_281(__this, p0, method) (( void (*) (t8_76 *, t1_1 *, const MethodInfo*))m8_281_gshared)(__this, p0, method)
