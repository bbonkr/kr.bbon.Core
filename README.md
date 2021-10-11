# kr.bbon.Core Package

[![](https://img.shields.io/nuget/v/kr.bbon.Core)](https://www.nuget.org/packages/kr.bbon.Core) [![](https://img.shields.io/nuget/dt/kr.bbon.Core)](https://www.nuget.org/packages/kr.bbon.Core) [![publish to nuget](https://github.com/bbonkr/kr.bbon.Core/actions/workflows/dotnet.yml/badge.svg)](https://github.com/bbonkr/kr.bbon.Core/actions/workflows/dotnet.yml)

## 📢 Overview

.NET 5 에서 프로젝트를 시작할 때, 반복적으로 작성하던 사항을 패키지로 정리했습니다.

## 🌈 Namespace

### kr.bbon.Core 네임스페이스

기본 네임스페이스로 kr.bbon.Core 를 사용합니다.

### kr.bbon.Core.Converters 네임스페이스

값 변환을 위한 기능을 제공하는 네임스페이스입니다.

## 🎯 Features

### Exception classes

#### ApiException class

API 예외를 표현하기 위해 사용됩니다.

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

> ApiException class 를 사용하십시오.

HTTP 예외를 표현하기 위해 사용됩니다.

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

> ApiException class 를 사용하십시오.

HTTP 예외와 상세 정보를 표현하기 위해 사용됩니다.

```csharp
throw new HttpStatusException(HttpStatusCode.BadRequest, new SomeDetails
{
    Id = "err111",
    Message = "AAA 속성의 값이 정수가 아닙니다.",
});
```

#### SomethingWrongException

> ApiException class 를 사용하십시오.

사용자 정의 예외를 표현하기 위해 사용합니다.

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

> ApiException class 를 사용하십시오.

사용자 정의 예외와 상세 정보를 표현하기 위해 사용합니다.

```csharp
throw new SomethingWrongException("데이터를 처리하지 못했습니다.", new SomeDetails 
{
    Id = "err111",
    Message = "AAA 속성의 값이 정수가 아닙니다.",
});
```

### Extension methods

#### Object.ToJson<T>() method

Object 클래스에 ToJson 메서드를 추가합니다.

객체의 인스턴스를 JSON 문자열로 직렬화하는 기능을 제공합니다.

```csharp
var sample = getSampleModel();
sample.ToJson();
```

JsonSerializerOptions 매개변수가 지정되지 않은 경우 아래 기본값을 사용합니다.

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

자바스크립트 밀리초 값을 DateTimeOffset 으로 변환합니다.

##### ToJavascriptDateMilliseconds method

DateTimeOffset 값을 자바스크립트 밀리초 값으로 변환합니다.

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

현재 AppDomain 의 어셈블리중 입력된 조건을 만족하는 어셈블리 목록을 수집합니다.

```csharp
var predicte = new Func<Type, bool>(t => t.Name == nameof(ApiException));

var assemblies = ReflectionHelper.CollectAssembly(predicte);
```

#### CollectTypes method

현재 AppDomain 의 타입중 조건을 만족하는 타입 목록을 수집합니다.

```csharp
var predicte = new Func<Type, bool>(t => t.Name == nameof(ApiException));

var types = ReflectionHelper.CollectTypes(predicte);
```