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

struct t14_15;
struct t14_15_marshaled;
struct t1_18;
struct t1_37;

#include "codegen/il2cpp-codegen.h"

extern "C" void m14_15 (t14_15 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" void m14_16 (t1_1 * __this , t14_15 * p0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" t14_15 * m14_17 (t1_1 * __this , t1_18* p0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" t14_15 * m14_18 (t1_1 * __this , t1_37 * p0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" t14_15 * m14_19 (t1_1 * __this , t1_37 * p0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" void t14_15_marshal(const t14_15& unmarshaled, t14_15_marshaled& marshaled);
extern "C" void t14_15_marshal_back(const t14_15_marshaled& marshaled, t14_15& unmarshaled);
extern "C" void t14_15_marshal_cleanup(t14_15_marshaled& marshaled);
