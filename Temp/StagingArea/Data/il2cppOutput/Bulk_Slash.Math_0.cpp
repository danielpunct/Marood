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

struct t1_1;
struct t1_18;

#include "class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "t1_33.h"
#include "t13_0.h"
#include "t13_0MD.h"
#include "t13_1.h"
#include "t13_1MD.h"
#include "t1_25.h"
#include "t1_20.h"
#include "t1_23.h"
#include "t1_1.h"
#include "t1_1MD.h"
#include "t1_37.h"
#include "t1_20MD.h"
#include "t1_4.h"
#include "t1_18.h"
#include "t1_340MD.h"
#include "t1_18MD.h"
#include "t1_340.h"
#include "t1_288.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern "C" void m13_0 (t13_1 * __this, float p0, float p1, const MethodInfo* method)
{
	{
		float L_0 = p0;
		__this->f8 = L_0;
		float L_1 = p1;
		__this->f9 = L_1;
		return;
	}
}
extern TypeInfo* t13_1_TI_var;
extern "C" bool m13_1 (t13_1 * __this, t1_1 * p0, const MethodInfo* method)
{
	static bool s_Il2CppMethodIntialized;
	if (!s_Il2CppMethodIntialized)
	{
		t13_1_TI_var = il2cpp_codegen_type_info_from_index(1541);
		s_Il2CppMethodIntialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	bool V_2 = false;
	{
		t1_1 * L_0 = p0;
		V_0 = ((((t1_1*)(t1_1 *)L_0) == ((t1_1*)(t1_1 *)NULL))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_000e;
		}
	}
	{
		V_1 = 0;
		goto IL_0041;
	}

IL_000e:
	{
		t1_1 * L_2 = p0;
		t1_37 * L_3 = m1_5(L_2, NULL);
		t13_1  L_4 = (*(t13_1 *)__this);
		t1_1 * L_5 = Box(t13_1_TI_var, &L_4);
		t1_37 * L_6 = m1_5(L_5, NULL);
		V_2 = ((((int32_t)((((t1_1*)(t1_37 *)L_3) == ((t1_1*)(t1_37 *)L_6))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_7 = V_2;
		if (!L_7)
		{
			goto IL_0032;
		}
	}
	{
		V_1 = 0;
		goto IL_0041;
	}

IL_0032:
	{
		t1_1 * L_8 = p0;
		bool L_9 = m13_2(__this, ((*(t13_1 *)((t13_1 *)UnBox (L_8, t13_1_TI_var)))), NULL);
		V_1 = L_9;
		goto IL_0041;
	}

IL_0041:
	{
		bool L_10 = V_1;
		return L_10;
	}
}
extern "C" bool m13_2 (t13_1 * __this, t13_1  p0, const MethodInfo* method)
{
	float V_0 = 0.0f;
	bool V_1 = false;
	int32_t G_B3_0 = 0;
	{
		float L_0 = (__this->f8);
		V_0 = L_0;
		t13_1  L_1 = p0;
		float L_2 = (L_1.f8);
		bool L_3 = m1_500((&V_0), L_2, NULL);
		if (!L_3)
		{
			goto IL_002d;
		}
	}
	{
		float L_4 = (__this->f9);
		V_0 = L_4;
		t13_1  L_5 = p0;
		float L_6 = (L_5.f9);
		bool L_7 = m1_500((&V_0), L_6, NULL);
		G_B3_0 = ((int32_t)(L_7));
		goto IL_002e;
	}

IL_002d:
	{
		G_B3_0 = 0;
	}

IL_002e:
	{
		V_1 = G_B3_0;
		goto IL_0031;
	}

IL_0031:
	{
		bool L_8 = V_1;
		return L_8;
	}
}
extern "C" int32_t m13_3 (t13_1 * __this, const MethodInfo* method)
{
	float V_0 = 0.0f;
	int32_t V_1 = 0;
	{
		float L_0 = (__this->f8);
		V_0 = L_0;
		int32_t L_1 = m1_501((&V_0), NULL);
		float L_2 = (__this->f9);
		V_0 = L_2;
		int32_t L_3 = m1_501((&V_0), NULL);
		V_1 = ((int32_t)((int32_t)((int32_t)((int32_t)L_1*(int32_t)((int32_t)397)))^(int32_t)L_3));
		goto IL_0028;
	}

IL_0028:
	{
		int32_t L_4 = V_1;
		return L_4;
	}
}
extern TypeInfo* t1_340_TI_var;
extern TypeInfo* t1_18_TI_var;
extern Il2CppCodeGenString* _stringLiteral4665;
extern "C" t1_18* m13_4 (t13_1 * __this, const MethodInfo* method)
{
	static bool s_Il2CppMethodIntialized;
	if (!s_Il2CppMethodIntialized)
	{
		t1_340_TI_var = il2cpp_codegen_type_info_from_index(28);
		t1_18_TI_var = il2cpp_codegen_type_info_from_index(11);
		_stringLiteral4665 = il2cpp_codegen_string_literal_from_index(4665);
		s_Il2CppMethodIntialized = true;
	}
	float V_0 = 0.0f;
	t1_18* V_1 = {0};
	{
		float L_0 = (__this->f8);
		V_0 = L_0;
		IL2CPP_RUNTIME_CLASS_INIT(t1_340_TI_var);
		t1_340 * L_1 = m1_3261(NULL, NULL);
		t1_288 * L_2 = (t1_288 *)VirtFuncInvoker0< t1_288 * >::Invoke(13 /* System.Globalization.NumberFormatInfo System.Globalization.CultureInfo::get_NumberFormat() */, L_1);
		t1_18* L_3 = m1_509((&V_0), L_2, NULL);
		float L_4 = (__this->f9);
		V_0 = L_4;
		t1_340 * L_5 = m1_3261(NULL, NULL);
		t1_288 * L_6 = (t1_288 *)VirtFuncInvoker0< t1_288 * >::Invoke(13 /* System.Globalization.NumberFormatInfo System.Globalization.CultureInfo::get_NumberFormat() */, L_5);
		t1_18* L_7 = m1_509((&V_0), L_6, NULL);
		IL2CPP_RUNTIME_CLASS_INIT(t1_18_TI_var);
		t1_18* L_8 = m1_437(NULL, _stringLiteral4665, L_3, L_7, NULL);
		V_1 = L_8;
		goto IL_003e;
	}

IL_003e:
	{
		t1_18* L_9 = V_1;
		return L_9;
	}
}
extern TypeInfo* t13_1_TI_var;
extern "C" void m13_5 (t1_1 * __this , const MethodInfo* method)
{
	static bool s_Il2CppMethodIntialized;
	if (!s_Il2CppMethodIntialized)
	{
		t13_1_TI_var = il2cpp_codegen_type_info_from_index(1541);
		s_Il2CppMethodIntialized = true;
	}
	{
		t13_1  L_0 = {0};
		m13_0(&L_0, (0.0f), (1.0f), NULL);
		((t13_1_SFs*)t13_1_TI_var->static_fields)->f0 = L_0;
		t13_1  L_1 = {0};
		m13_0(&L_1, (-1.0f), (-1.0f), NULL);
		((t13_1_SFs*)t13_1_TI_var->static_fields)->f1 = L_1;
		t13_1  L_2 = {0};
		m13_0(&L_2, (1.0f), (1.0f), NULL);
		((t13_1_SFs*)t13_1_TI_var->static_fields)->f2 = L_2;
		t13_1  L_3 = {0};
		m13_0(&L_3, (1.0f), (0.0f), NULL);
		((t13_1_SFs*)t13_1_TI_var->static_fields)->f3 = L_3;
		((t13_1_SFs*)t13_1_TI_var->static_fields)->f4 = (-1.57079637f);
		t13_1  L_4 = {0};
		m13_0(&L_4, (1.0f), (0.0f), NULL);
		((t13_1_SFs*)t13_1_TI_var->static_fields)->f5 = L_4;
		t13_1  L_5 = {0};
		m13_0(&L_5, (0.0f), (1.0f), NULL);
		((t13_1_SFs*)t13_1_TI_var->static_fields)->f6 = L_5;
		t13_1  L_6 = {0};
		m13_0(&L_6, (0.0f), (0.0f), NULL);
		((t13_1_SFs*)t13_1_TI_var->static_fields)->f7 = L_6;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
