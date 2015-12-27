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

struct t14_14;
struct t14_14_marshaled;

#include "codegen/il2cpp-codegen.h"

extern "C" void m14_12 (t14_14 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" void m14_13 (t14_14 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" void m14_14 (t14_14 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" void t14_14_marshal(const t14_14& unmarshaled, t14_14_marshaled& marshaled);
extern "C" void t14_14_marshal_back(const t14_14_marshaled& marshaled, t14_14& unmarshaled);
extern "C" void t14_14_marshal_cleanup(t14_14_marshaled& marshaled);
