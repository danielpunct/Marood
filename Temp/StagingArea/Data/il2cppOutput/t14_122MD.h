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

struct t14_122;
struct t14_122_marshaled;
struct t1_1;

#include "codegen/il2cpp-codegen.h"

extern "C" bool m14_1303 (t14_122 * __this, t1_1 * p0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" int32_t m14_1304 (t14_122 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" bool m14_1305 (t1_1 * __this , t14_122 * p0, t14_122 * p1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" void t14_122_marshal(const t14_122& unmarshaled, t14_122_marshaled& marshaled);
extern "C" void t14_122_marshal_back(const t14_122_marshaled& marshaled, t14_122& unmarshaled);
extern "C" void t14_122_marshal_cleanup(t14_122_marshaled& marshaled);
