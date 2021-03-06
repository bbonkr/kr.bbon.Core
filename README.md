# kr.bbon.Core Package

[![](https://img.shields.io/nuget/v/kr.bbon.Core)](https://www.nuget.org/packages/kr.bbon.Core) [![](https://img.shields.io/nuget/dt/kr.bbon.Core)](https://www.nuget.org/packages/kr.bbon.Core) [![publish to nuget](https://github.com/bbonkr/kr.bbon.Core/actions/workflows/build-tag.yaml/badge.svg)](https://github.com/bbonkr/kr.bbon.Core/actions/workflows/build-tag.yaml)

## π’ Overview

.NET μμ νλ‘μ νΈλ₯Ό μμν  λ, λ°λ³΅μ μΌλ‘ μμ±νλ μ¬ν­μ ν¨ν€μ§λ‘ μ λ¦¬νμ΅λλ€.

## π Namespace

### kr.bbon.Core λ€μμ€νμ΄μ€

κΈ°λ³Έ λ€μμ€νμ΄μ€λ‘ kr.bbon.Core λ₯Ό μ¬μ©ν©λλ€.

### kr.bbon.Core.Converters λ€μμ€νμ΄μ€

κ° λ³νμ μν κΈ°λ₯μ μ κ³΅νλ λ€μμ€νμ΄μ€μλλ€.

## π― Features

### Exception classes

#### ApiException class

API μμΈλ₯Ό νννκΈ° μν΄ μ¬μ©λ©λλ€.

```csharp
public Task SomeFeatureAsync()
{
    if(NotValid){
        var model = new ErrorModel("It's invalid message");
        throw new ApiException(400, model);
    }
    // ...
}
```

#### HttpStatusException class

> ApiException class λ₯Ό μ¬μ©νμ­μμ€.

HTTP μμΈλ₯Ό νννκΈ° μν΄ μ¬μ©λ©λλ€.

```csharp
// Exception handling in action method
try
{
    // ...
}
catch(HttpStatusException ex)
{
    return StatusCode(ex.StatusCode, ex.Message, ex.GetDetails());
}
catch(Exception ex)
{
    // ...
}
```

#### HttpStatusException<TDeatails> class

> ApiException class λ₯Ό μ¬μ©νμ­μμ€.

HTTP μμΈμ μμΈ μ λ³΄λ₯Ό νννκΈ° μν΄ μ¬μ©λ©λλ€.

```csharp
throw new HttpStatusException(HttpStatusCode.BadRequest, new SomeDetails
{
    Id = "err111",
    Message = "AAA μμ±μ κ°μ΄ μ μκ° μλλλ€.",
});
```

#### SomethingWrongException

> ApiException class λ₯Ό μ¬μ©νμ­μμ€.

μ¬μ©μ μ μ μμΈλ₯Ό νννκΈ° μν΄ μ¬μ©ν©λλ€.

```csharp
// Exception handling in action method 
try
{
    // ...
}
catch(SomethingWrongException ex)
{
    return StatusCode(HttpStatusCode.Forbidden, ex.Message, ex.GetDetails());
}
catch(Exception ex)
{
    // ...
}
```

#### SomethingWrongException<TDetails>

> ApiException class λ₯Ό μ¬μ©νμ­μμ€.

μ¬μ©μ μ μ μμΈμ μμΈ μ λ³΄λ₯Ό νννκΈ° μν΄ μ¬μ©ν©λλ€.

```csharp
throw new SomethingWrongException("λ°μ΄ν°λ₯Ό μ²λ¦¬νμ§ λͺ»νμ΅λλ€.", new SomeDetails 
{
    Id = "err111",
    Message = "AAA μμ±μ κ°μ΄ μ μκ° μλλλ€.",
});
```

### Extension methods

#### Object.ToJson<T>() method

Object ν΄λμ€μ ToJson λ©μλλ₯Ό μΆκ°ν©λλ€.

κ°μ²΄μ μΈμ€ν΄μ€λ₯Ό JSON λ¬Έμμ΄λ‘ μ§λ ¬ννλ κΈ°λ₯μ μ κ³΅ν©λλ€.

```csharp
var sample = getSampleModel();
sample.ToJson();
```

JsonSerializerOptions λ§€κ°λ³μκ° μ§μ λμ§ μμ κ²½μ° μλ κΈ°λ³Έκ°μ μ¬μ©ν©λλ€.

```csharp
var defaultOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};
```

### kr.bbon.Core.Converters namespace

#### JavascriptDateConverter class

##### ToDateTimeOffset method

μλ°μ€ν¬λ¦½νΈ λ°λ¦¬μ΄ κ°μ DateTimeOffset μΌλ‘ λ³νν©λλ€.

##### ToJavascriptDateMilliseconds method

DateTimeOffset κ°μ μλ°μ€ν¬λ¦½νΈ λ°λ¦¬μ΄ κ°μΌλ‘ λ³νν©λλ€.

```csharp
JavascriptDateConverter converter = new JavascriptDateConverter();
var javascriptDateValue = 1624165031491;
var datetimeOffsetValue = converter.ToDateTimeOffset(javascriptDateValue);
var milliseconds = converter.ToJavascriptDateMilliseconds(datetimeOffsetValue);

Assert.Equal(javascriptDateValue, milliseconds.Value);
```


### kr.bbon.Core.Reflection namespace 

### ReflectionHelper class

#### CollectAssembly method

νμ¬ AppDomain μ μ΄μλΈλ¦¬μ€ μλ ₯λ μ‘°κ±΄μ λ§μ‘±νλ μ΄μλΈλ¦¬ λͺ©λ‘μ μμ§ν©λλ€.

```csharp
var predicte = new Func<Type, bool>(t => t.Name == nameof(ApiException));

var assemblies = ReflectionHelper.CollectAssembly(predicte);
```

#### CollectTypes method

νμ¬ AppDomain μ νμμ€ μ‘°κ±΄μ λ§μ‘±νλ νμ λͺ©λ‘μ μμ§ν©λλ€.

```csharp
var predicte = new Func<Type, bool>(t => t.Name == nameof(ApiException));

var types = ReflectionHelper.CollectTypes(predicte);
```