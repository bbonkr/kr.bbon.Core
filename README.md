# kr.bbon.Core Package

[![](https://img.shields.io/nuget/v/kr.bbon.Core)](https://www.nuget.org/packages/kr.bbon.Core) [![](https://img.shields.io/nuget/dt/kr.bbon.Core)](https://www.nuget.org/packages/kr.bbon.Core) [![publish to nuget](https://github.com/bbonkr/kr.bbon.Core/actions/workflows/dotnet.yml/badge.svg)](https://github.com/bbonkr/kr.bbon.Core/actions/workflows/dotnet.yml)

## 📢 Overview

.NET 5 에서 프로젝트를 시작할 때, 반복적으로 작성하던 사항을 패키지로 정리했습니다.

## 🌈 Namespace

### kr.bbon.Core

기본 네임스페이스로 kr.bbon.Core 를 사용합니다.

## 🎯 Features

### Exception classes

#### HttpStatusException class

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

HTTP 예외와 상세 정보를 표현하기 위해 사용됩니다.

```csharp
throw new HttpStatusException(HttpStatusCode.BadRequest, new SomeDetails
{
    Id = "err111",
    Message = "AAA 속성의 값이 정수가 아닙니다.",
});
```

#### SomethingWrongException

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