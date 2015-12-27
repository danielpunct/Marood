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

struct t14_301;
struct t1_1;
struct t1_35;
struct t1_36;

#include "codegen/il2cpp-codegen.h"
#include "t1_24.h"
#include "t14_35.h"

extern "C" void m14_1620_gshared (t14_301 * __this, t1_1 * p0, t1_24 p1, const MethodInfo* method);
#define m14_1620(__this, p0, p1, method) (( void (*) (t14_301 *, t1_1 *, t1_24, const MethodInfo*))m14_1620_gshared)(__this, p0, p1, method)
extern "C" void m14_1621_gshared (t14_301 * __this, t14_35  p0, const MethodInfo* method);
#define m14_1621(__this, p0, method) (( void (*) (t14_301 *, t14_35 , const MethodInfo*))m14_1621_gshared)(__this, p0, method)
extern "C" t1_1 * m14_1622_gshared (t14_301 * __this, t14_35  p0, t1_36 * p1, t1_1 * p2, const MethodInfo* method);
#define m14_1622(__this, p0, p1, p2, method) (( t1_1 * (*) (t14_301 *, t14_35 , t1_36 *, t1_1 *, const MethodInfo*))m14_1622_gshared)(__this, p0, p1, p2, method)
extern "C" void m14_1623_gshared (t14_301 * __this, t1_1 * p0, const MethodInfo* method);
#define m14_1623(__this, p0, method) (( void (*) (t14_301 *, t1_1 *, const MethodInfo*))m14_1623_gshared)(__this, p0, method)
