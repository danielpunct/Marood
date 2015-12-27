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

struct t14_11;
struct t14_11_marshaled;

#include "codegen/il2cpp-codegen.h"

extern "C" void m14_631 (t14_11 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
extern "C" void t14_11_marshal(const t14_11& unmarshaled, t14_11_marshaled& marshaled);
extern "C" void t14_11_marshal_back(const t14_11_marshaled& marshaled, t14_11& unmarshaled);
extern "C" void t14_11_marshal_cleanup(t14_11_marshaled& marshaled);
