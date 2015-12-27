#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>

struct t16_1;
struct t16_2;
struct t16_3;
struct t1_18;
struct t16_4;
struct t1_1;
struct t16_5;

#include "class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "t1_33.h"
#include "t16_0.h"
#include "t16_0MD.h"
#include "t16_1.h"
#include "t16_1MD.h"
#include "t1_25.h"
#include "t1_3MD.h"
#include "t1_3.h"
#include "t16_2.h"
#include "t16_2MD.h"
#include "t1_23.h"
#include "t16_3.h"
#include "t16_3MD.h"
#include "t1_18.h"
#include "t16_4MD.h"
#include "t16_4.h"
#include "t1_20.h"
#include "t1_18MD.h"
#include "mscorlib_ArrayTypes.h"
#include "t1_1.h"
#include "t16_5.h"
#include "t16_5MD.h"
#include "t1_1MD.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern "C" void m16_0 (t16_1 * __this, const MethodInfo* method)
{
	{
		m1_17(__this, NULL);
		return;
	}
}
extern "C" void m16_1 (t16_2 * __this, const MethodInfo* method)
{
	{
		m16_0(__this, NULL);
		m16_2(__this, 1, NULL);
		return;
	}
}
extern "C" void m16_2 (t16_2 * __this, bool p0, const MethodInfo* method)
{
	{
		bool L_0 = p0;
		__this->f0 = L_0;
		return;
	}
}
extern "C" void m16_3 (t16_3 * __this, t1_18* p0, const MethodInfo* method)
{
	{
		t1_18* L_0 = p0;
		m16_9(__this, L_0, NULL);
		m16_7(__this, (-std::numeric_limits<float>::max()), NULL);
		m16_5(__this, (std::numeric_limits<float>::max()), NULL);
		return;
	}
}
extern "C" float m16_4 (t16_3 * __this, const MethodInfo* method)
{
	{
		float L_0 = (__this->f3);
		return L_0;
	}
}
extern "C" void m16_5 (t16_3 * __this, float p0, const MethodInfo* method)
{
	{
		float L_0 = p0;
		__this->f3 = L_0;
		return;
	}
}
extern "C" float m16_6 (t16_3 * __this, const MethodInfo* method)
{
	{
		float L_0 = (__this->f4);
		return L_0;
	}
}
extern "C" void m16_7 (t16_3 * __this, float p0, const MethodInfo* method)
{
	{
		float L_0 = p0;
		__this->f4 = L_0;
		return;
	}
}
extern TypeInfo* t1_336_TI_var;
extern TypeInfo* t1_20_TI_var;
extern TypeInfo* t1_18_TI_var;
extern Il2CppCodeGenString* _stringLiteral4876;
extern "C" t1_18* m16_8 (t16_3 * __this, const MethodInfo* method)
{
	static bool s_Il2CppMethodIntialized;
	if (!s_Il2CppMethodIntialized)
	{
		t1_336_TI_var = il2cpp_codegen_type_info_from_index(19);
		t1_20_TI_var = il2cpp_codegen_type_info_from_index(43);
		t1_18_TI_var = il2cpp_codegen_type_info_from_index(11);
		_stringLiteral4876 = il2cpp_codegen_string_literal_from_index(4876);
		s_Il2CppMethodIntialized = true;
	}
	t1_18* V_0 = {0};
	{
		t1_336* L_0 = ((t1_336*)SZArrayNew(t1_336_TI_var, 4));
		t1_18* L_1 = m16_13(__this, NULL);
		ArrayElementTypeCheck (L_0, L_1);
		*((t1_1 **)(t1_1 **)SZArrayLdElema(L_0, 0, sizeof(t1_1 *))) = (t1_1 *)L_1;
		t1_336* L_2 = L_0;
		float L_3 = m16_4(__this, NULL);
		float L_4 = L_3;
		t1_1 * L_5 = Box(t1_20_TI_var, &L_4);
		ArrayElementTypeCheck (L_2, L_5);
		*((t1_1 **)(t1_1 **)SZArrayLdElema(L_2, 1, sizeof(t1_1 *))) = (t1_1 *)L_5;
		t1_336* L_6 = L_2;
		float L_7 = m16_6(__this, NULL);
		float L_8 = L_7;
		t1_1 * L_9 = Box(t1_20_TI_var, &L_8);
		ArrayElementTypeCheck (L_6, L_9);
		*((t1_1 **)(t1_1 **)SZArrayLdElema(L_6, 2, sizeof(t1_1 *))) = (t1_1 *)L_9;
		t1_336* L_10 = L_6;
		t1_1 * L_11 = m16_10(__this, NULL);
		ArrayElementTypeCheck (L_10, L_11);
		*((t1_1 **)(t1_1 **)SZArrayLdElema(L_10, 3, sizeof(t1_1 *))) = (t1_1 *)L_11;
		IL2CPP_RUNTIME_CLASS_INIT(t1_18_TI_var);
		t1_18* L_12 = m1_439(NULL, _stringLiteral4876, L_10, NULL);
		V_0 = L_12;
		goto IL_0042;
	}

IL_0042:
	{
		t1_18* L_13 = V_0;
		return L_13;
	}
}
extern "C" void m16_9 (t16_4 * __this, t1_18* p0, const MethodInfo* method)
{
	{
		m1_17(__this, NULL);
		t1_18* L_0 = p0;
		m16_14(__this, L_0, NULL);
		return;
	}
}
extern "C" t1_1 * m16_10 (t16_4 * __this, const MethodInfo* method)
{
	{
		t1_1 * L_0 = (__this->f0);
		return L_0;
	}
}
extern "C" void m16_11 (t16_4 * __this, t1_1 * p0, const MethodInfo* method)
{
	{
		t1_1 * L_0 = p0;
		__this->f0 = L_0;
		return;
	}
}
extern "C" void m16_12 (t16_4 * __this, t1_18* p0, const MethodInfo* method)
{
	{
		t1_18* L_0 = p0;
		__this->f1 = L_0;
		return;
	}
}
extern "C" t1_18* m16_13 (t16_4 * __this, const MethodInfo* method)
{
	{
		t1_18* L_0 = (__this->f2);
		return L_0;
	}
}
extern "C" void m16_14 (t16_4 * __this, t1_18* p0, const MethodInfo* method)
{
	{
		t1_18* L_0 = p0;
		__this->f2 = L_0;
		return;
	}
}
extern TypeInfo* t1_18_TI_var;
extern Il2CppCodeGenString* _stringLiteral4877;
extern "C" t1_18* m16_15 (t16_4 * __this, const MethodInfo* method)
{
	static bool s_Il2CppMethodIntialized;
	if (!s_Il2CppMethodIntialized)
	{
		t1_18_TI_var = il2cpp_codegen_type_info_from_index(11);
		_stringLiteral4877 = il2cpp_codegen_string_literal_from_index(4877);
		s_Il2CppMethodIntialized = true;
	}
	t1_18* V_0 = {0};
	{
		t1_18* L_0 = m16_13(__this, NULL);
		t1_1 * L_1 = m16_10(__this, NULL);
		IL2CPP_RUNTIME_CLASS_INIT(t1_18_TI_var);
		t1_18* L_2 = m1_437(NULL, _stringLiteral4877, L_0, L_1, NULL);
		V_0 = L_2;
		goto IL_001a;
	}

IL_001a:
	{
		t1_18* L_3 = V_0;
		return L_3;
	}
}
extern "C" void m16_16 (t16_5 * __this, const MethodInfo* method)
{
	{
		m1_0(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
