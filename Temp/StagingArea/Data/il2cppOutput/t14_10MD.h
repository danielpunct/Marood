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

struct t14_10;
struct t14_10_marshaled;

#include "codegen/il2cpp-codegen.h"

extern "C" void m14_9 (t14_10 * __this, float p0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" void t14_10_marshal(const t14_10& unmarshaled, t14_10_marshaled& marshaled);
extern "C" void t14_10_marshal_back(const t14_10_marshaled& marshaled, t14_10& unmarshaled);
extern "C" void t14_10_marshal_cleanup(t14_10_marshaled& marshaled);
