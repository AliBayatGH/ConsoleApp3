# Table of Contents
- [Introduction](#introduction)
- [Quick start ](#quick-start)
- [Git ](#git)
     - [Git Branching Naming Convention](#git-branching-naming-convention) 
- [Testing](#testing)
- [ Logging](#logging)
- [ Environments](#Environments)
- [ Docker](#docker)
- [ Boundaries](#boundaries)
- [Services](#services)
- [Conventions](#clean-code-net)
  - [Naming](#naming)
  - [Variables](#variables)
  - [Functions](#functions)
  - [Objects and Data Structures](#objects-and-data-structures)
  - [Classes](#classes)
  - [SOLID](#solid)
  - [Concurrency](#concurrency)
  - [Error Handling](#error-handling)
  - [Formatting](#formatting)
  - [Comments](#comments)
- [Miscellaneous](#miscellaneous)
  - [Guidelines](#guidelines)
  - [Identity](#identity)
  - [Repository](#repository)
  - [Project Template](#project-template)
  - [Google ReCAPTCHA](#google-reCAPTCHA)
  - [Shared Context](#shared-context)
  - [Domain](#domain)
  - [Guidelines](#guidelines)
- [Release Notes](#release-notes)

# Introduction
 It's a guide to producing readable, reusable, and refactorable software in .NET. These are guidelines and nothing more, but they are ones codified over many years of collective experience by the authors of _Clean Code.

# Quick start
 ## Step 1 
Implement the core, business logic of the domain
**Domain layer**
 1. &emsp;Aggregate 
   &emsp;&emsp;Define the Rich domain model
 2. &emsp;Value objects
	 &emsp; &emsp;Each complex value with no identity must be modeled and treated as a value object.
         &emsp; &emsp;Define value objects to avoid primitive obsessions. 
  3. &emsp;IRepository
   &emsp;Define repositories interrface.

## Step 2
Implement the use cases of the application based on the domain. A use case can be thought as a user interaction on the UI.
**Application layer**
  1. &emsp;Command
   &emsp; &emsp;Define commands and command handlers
  2. &emsp;Event
   &emsp; &emsp;Implement event handlers(Domain and Integration event)
  3. &emsp;Configure services
   &emsp; &emsp;Register the Commandhanlers using `AddCommandHandler` method inside `CommandHandlerServiceCollectionExtensions` class
   &emsp; &emsp;Register the Queryhanlers using `AddQueryHandler` method inside `QueryHandlerServiceCollectionExtensions` calss
   &emsp; &emsp;Register the Eventhanlers using `AddEventHandler` method inside `EventHandlerServiceCollectionExtensions` calss

## Step 3
Implement the abstractions and integrations to 3rd-party libraries.
**Infrastructure layer** 
  1. &emsp;Repository
   &emsp; &emsp;Implement repositories
  2. &emsp;EntityTypeConfiguration
   &emsp; &emsp;Add the EntityTypeConfiguration class to EntityTypeConfigurations folder
   &emsp; &emsp;Call the ApplyConfiguration on OnModelCreating of DbContext class
  3. &emsp;Configure services
   &emsp; &emsp;Register Repository services inside ServiceCollectionExtensions(AddDataEntityFrameworkServices method)
  4. &emsp;Migrations
   &emsp;Add the migration
    &emsp; &emsp;`Add-Migration -p Hasti.[ProductName].Data.EntityFramework -s Hasti.[ProductName].Endpoints.WepApi`

## Step 4
**Endpoints layer**
1.&emsp; Add the controllers
  &emsp;&emsp;&emsp;Add the Input and result models
 &emsp;&emsp;&emsp;Add the mappings
 &emsp;&emsp;&emsp;Create API endpoints and dispatch commands


\\\172.27.226.6\Developer\Ali.Bayat\HastiFramework\QuickStart.mp4


**[⬆ Back to top](#table-of-contents)**
# Git
**SSL certificate problem:** unable to get local issuer certificate:

git config --global http.sslVerify false

**Default Branch:**
AzureDevOps => Repos=> Branches => More => Set as default branches

<div dir=rtl>

برای هر Feature جدید یک برنچ از روی develop درست می کنیم

git checkout develop
git checkout -b feature/feature1

یا

git flow feature start feature1


کارمون روی برنچ Feature تموم شد با develop مرج می کنیم(قبل از مرج کردن Pull request میدهیم تا کدهای ما پس از Review با develop مرج شود)
git checkout develop
git merge feature/feature1

هر وقت می خواهیم release بدیم یک برنچ از روی develop درست می کنیم با تگ ورژن
git checkout develop
git checkout -b release/1.0

وقتی release آماده پابلیش شد با master مرج می کنیم. (قبل از مرج کردن Pull request میدهیم تا کدهای ما پس از Review با master مرج شود)
git checkout master
git merge release/0.1.0

برنچ hotfix هم که مستقیم از master گرفته میشه و وقتی کارش تموم شد با برنچ های master و develop و release مرج میشه
برای ساختن برنچ hotfix از دستور زیر استفاده می کنیم
git checkout master
git checkout -b hotfix_branch


بعدش با master و develop و اگه release داشته باشیم مرجش می کنیم.
git checkout master
git merge hotfix1
git checkout develop
git merge hotfix1
git branch -D hotfix1
</div>


The **Develop** branch’s idea is to make changes in it and restrict the developers from making any changes in the **master** branch directly. Changes in the Develop branch undergo reviews and, after testing, get merged with the **master** branch.
**Master** branch should be **stable all the time** and won’t allow any direct push. You can only merge it after code review.

**Develop Branch**: A pull request is created by developers from their respective feature branches to merge code to the develop branch. Usually, it is created after features are completed. A pull request is merged to the develop branch by the reviewer.
**Release Branch**: A pull request is created by a developer from a feature or bugfix branch to merge code to the release branch. Usually, it is created during release time when a bug needs to be fixed in the release branch.
**Master Branch**: A pull request is created by a developer from the release branch to merge code to the master branch. Usually, it is created during release time when the code is ready for deployment. 
**Hotfix Branch**: A pull request is created by developers from their respective bugfix branches to merge code to both the master and develop branches. Usually, it is created to provide a critical fix in the deployed code. The pull request is merged by a reviewer. This merge request should be reviewed with more care as it will directly merge the code to the master branch.

## Git Branching Naming Convention:

- Start branch name with a Group word
- Use Hyphen as Separators 
  bug – The bug which needs to be fixed soon
  task – The work is in progress, and I am aware it will not finish soon
 For example:
  **task-ordering-sample-added** 

- Use Unique ID in branch names
  The name shows that the branch applies to the task of adding a testing module, the tracking Id of the issue is 84, and the work is in progress.
 
  For example:
   **task-84-ordering-sample-added** 

- Git Branch with Author Name
 **ali.bayat-task-84-ordering-sample-added** 


------------
Gitflow cheetahs

git flow feature start MYFEATURE
git flow feature finish MYFEATURE
git flow feature publish MYFEATURE
git flow feature pull origin MYFEATURE

git flow release start RELEASE [BASE]
git flow release finish RELEASE

git flow hotfix start VERSION [BASENAME]
git flow hotfix finish VERSION

## Commit Messages guidelines
**What is a good commit message?**
This is the same idea as `clean code` functions. Each function does basically what it says it will do. Likewise, a good commit will do exactly what its commit message says it would. Your message should also be in the imperative active voice.

To come up with good commits, consider the following:
- Why have I made these changes?
- What effect have my changes made?
- Why was the change needed?
- What are the changes in reference to?

**A good commit message should be:**
- Less than 72 characters and written in the imperative mood. Example – A_dd the cancelation token input to command - handers_ 
- Describe the change introduced by the commit.
- Tell the story of how your project has evolved.
- Specify the type of commit. Example: **Bugfix**, **Update**, **Refactor**, and so on.

The commit type can include the following:

**feature** – a new feature is introduced with the changes
**fix** – a bug fix has occurred
**refactor** – refactored code that neither fixes a bug nor adds a feature
**style** – changes that do not affect the meaning of the code, likely related to code formatting.
**test** – including new or correcting previous tests
**performance** – performance improvements
**revert** – reverts a previous commit



**[⬆ Back to top](#table-of-contents)**
---
# Testing

<details>
  <summary><b>Basic concept of testing</b></summary>

Testing is more important than shipping. If you have no tests or an inadequate amount, then every time you ship code you won't be sure that you didn't break anything. Deciding on what constitutes an adequate amount is up to your team, but having 100% coverage (all statements and branches) is how you achieve very high confidence and developer peace of mind. This means that in addition to having a great testing framework, you also need to use a [good coverage tool](https://docs.microsoft.com/en-us/visualstudio/test/using-code-coverage-to-determine-how-much-code-is-being-tested).
</details>

<details>
  <summary><b>Single concept per test</b></summary>

Ensures that your tests are laser focused and not testing miscellaenous (non-related) things, forces [AAA patern](http://wiki.c2.com/?ArrangeActAssert) used to make your codes more clean and readable.

**Bad:**

```csharp

public class MakeDotNetGreatAgainTests
{
    [Fact]
    public void HandleDateBoundaries()
    {
        var date = new MyDateTime("1/1/2015");
        date.AddDays(30);
        Assert.Equal("1/31/2015", date);

        date = new MyDateTime("2/1/2016");
        date.AddDays(28);
        Assert.Equal("02/29/2016", date);

        date = new MyDateTime("2/1/2015");
        date.AddDays(28);
        Assert.Equal("03/01/2015", date);
    }
}

```

**Good:**

```csharp

public class MakeDotNetGreatAgainTests
{
    [Fact]
    public void Handle30DayMonths()
    {
        // Arrange
        var date = new MyDateTime("1/1/2015");

        // Act
        date.AddDays(30);

        // Assert
        Assert.Equal("1/31/2015", date);
    }

    [Fact]
    public void HandleLeapYear()
    {
        // Arrange
        var date = new MyDateTime("2/1/2016");

        // Act
        date.AddDays(28);

        // Assert
        Assert.Equal("02/29/2016", date);
    }

    [Fact]
    public void HandleNonLeapYear()
    {
        // Arrange
        var date = new MyDateTime("2/1/2015");

        // Act
        date.AddDays(28);

        // Assert
        Assert.Equal("03/01/2015", date);
    }
}

```

## Unit test
A **unit test** is a test that meets the following requirements:
- Verify a single unit of behavior,
- Does it quickly,
- And does it in isolation from other tests.

## Integration test
**Integration tests** verify how your system integrates with out-of-process dependencies.

Unit test cover **domain model**; Integration test cover **controllers**

The majority of tests should be unit tests

Use a real instance of **managed dependencies**(Like databases, that are only accessible through your application)
Replace **unmanaged dependencies** with mocks. (Like SMTP server and a Message Bus, that other applications have access to it)

The general guideline for integration testing is to cover the **longest happy path** and any edge cases that can’t be exercised by unit tests. The longest happy path is the one that goes through all out-of-process dependencies.

Having more than one **arrange**, **act**, or **assert** section in a test is a code smell.


## Unit test naming guidelines
Remember, you are not testing code, you are testing application behavior. So it does not matter what the name of the method under test is. name the test as if you were describing the scenario to a non-programmer who is familiar with the problem domain.

But to get started, you can follow the naming conventions below:

`[MethodUnderTest]_[Scenario]_[ExpectedResult]`

where
- **MethodUnderTest** is the name of the method you are testing.
- **Scenario** is the condition under which you test the method
- **ExpectedResult** is what you expect the method under test to do in the current scenario.

For example
`Sum_TwoNumbers_ReturnsSum()`
or simply you can name it
`Sum_of_two_numbers()`

`IsDeliveryValid_InvalidDate_ReturnsFalse()`
 `Delivery_with_invalid_date_should_be_considered_invalid()`
 `Delivery_with_past_date_should_be_considered_invalid()`
`Delivery_with_past_date_should_be_invalid()`
 `Delivery_with_past_date_is_invalid()`

 `Can_detect_an_invalid_delivery_date`


**[⬆ back to top](#table-of-contents)**

</details>

# Logging

## Logging providers

- Console
- Sentry

## Create logs
To create logs, use an  [ILogger<TCategoryName>](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1)  object from  [dependency injection (DI)](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0).

The following example:

-   Creates a logger,  `ILogger<AboutModel>`, which uses a log  _category_  of the fully qualified name of the type  `AboutModel`. The log category is a string that is associated with each log.
-   Calls  LogInformation  level. The Log  _level_  indicates the severity of the logged event.

```
public class UserController
{
    private readonly ILogger _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    public void Get()
    {
        _logger.LogInformation("About page visited at {DT}", 
            DateTime.UtcNow.ToLongTimeString());
    }
}
```
## Configure logging

### Add the logger to the project :

We use the **Serilog** library for the logger.
We use the **Sentry** tool for _Error Tracking_.

Add the logger to the project, we do the following steps:

1) Update `Program.cs` file :

     Add `builder.ConfigureLogging();` 


2) Update `appsetting.json` file ;

             Add json model :
             "Sentry": {
                  "Dsn": "https://5f9fc78749fd4a0cbe9765234d70b596@sentry.hasti.co/2",
                  "MaxRequestBodySize": "Always",
                  "SendDefaultPii": true,
                  "MinimumBreadcrumbLevel": "Debug",
                  "MinimumEventLevel": "Warning",
                  "AttachStackTrace": true,
                  "Debug": true,
                  "DiagnosticsLevel": "Error"
             }

<div dir='rtl'>
ثبت و ارسال لاگ در Sentry :

یه وقتایی خطاهایی که رخ میده ما نیاز داریم یه سری موارد رو سرچ کنیم و یه سری اطلاعات بدست بیاریم و خطا را ردیابی کنیم که بتونیم خطا رو برطرف کنیم مثل :

چه خطایی رخ داده ؟
کاربری چیه؟
سیستم عامل چیه؟
ورژن سیستم عامل چنده؟
کدوم API؟
چه اطلاعاتی ارسال شده؟
چه Exception داره؟
پیغام خطا چیه؟

برای این منظور یه سری کوئری ها در محیط  Sentry مینویسیم که سریعتر به نتیجه برسیم.

جستجوی لاگ ها براساس ویژگی های مانند :
</div>
environment,
level,
error.handled,
error.unhandled,
message,
transaction,
...
<div dir='rtl'>
ایجاد کوئری :

<div dir='rtl'>Discover -> Build a new query </div>

کوئری رو میتونیم با یک نام ذخیره کنیم که بصورت یک کارت در صفحه Discover نمایش داده میشود

یک نمونه کوئری :
</div>
           
```
environment:development
           level:error
           error.handled:true
           message:This is a test locality error1!
           transaction:"GET Locality/Geos" 
           route.action:GetAll 
           server_name:DESKTOP-GM9A8SP 
           url:http://dev-catalog/api/Attribute/989027598191296512 
           traceId:0HMIK5OS1TRDO:00000004
```


<div dir='rtl'>
لاگ زدن بین چند سرویس (Correlating logging between  services) :

استفاده از TraceId  : برای ردیابی کردن لاگ بین چند سرویس


همچنین میتوان ستون های جدول نتایج رو تغییر داد و براساس نیاز خود ستون ها را نمایش دهیم
</div>

 Discover -> Results -> Column

**[⬆ back to top](#table-of-contents)**

## Naming

<details>
  <summary><b>Avoid using bad names</b></summary>
A good name allows the code to be used by many developers. The name should reflect what it does and give context.

**Bad:**

```csharp
int d;
```

**Good:**

```csharp
int daySinceModification;
```

**[⬆ Back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Avoid Misleading Names</b></summary>

Name the variable to reflect what it is used for.

**Bad:**

```csharp
var dataFromDb = db.GetFromService().ToList();
```

**Good:**

```csharp
var listOfEmployee = _employeeService.GetEmployees().ToList();
```

**[⬆ Back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Avoid Hungarian notation</b></summary>

Hungarian Notation restates the type which is already present in the declaration. This is pointless since modern IDEs will identify the type.

**Bad:**

```csharp
int iCounter;
string strFullName;
DateTime dModifiedDate;
```

**Good:**

```csharp
int counter;
string fullName;
DateTime modifiedDate;
```

Hungarian Notation should also not be used in paramaters.

**Bad:**

```csharp
public bool IsShopOpen(string pDay, int pAmount)
{
    // some logic
}
```

**Good:**

```csharp
public bool IsShopOpen(string day, int amount)
{
    // some logic
}
```

**[⬆ Back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use consistent capitalization</b></summary>

Capitalization tells you a lot about your variables,
functions, etc. These rules are subjective, so your team can choose whatever
they want. The point is, no matter what you all choose, just be consistent.

**Bad:**

```csharp
const int DAYS_IN_WEEK = 7;
const int daysInMonth = 30;

var songs = new List<string> { 'Back In Black', 'Stairway to Heaven', 'Hey Jude' };
var Artists = new List<string> { 'ACDC', 'Led Zeppelin', 'The Beatles' };

bool EraseDatabase() {}
bool Restore_database() {}

class animal {}
class Alpaca {}
```

**Good:**

```csharp
const int DaysInWeek = 7;
const int DaysInMonth = 30;

var songs = new List<string> { 'Back In Black', 'Stairway to Heaven', 'Hey Jude' };
var artists = new List<string> { 'ACDC', 'Led Zeppelin', 'The Beatles' };

bool EraseDatabase() {}
bool RestoreDatabase() {}

class Animal {}
class Alpaca {}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use pronounceable names</b></summary>

It will take time to investigate the meaning of the variables and functions when they are not pronounceable.

**Bad:**

```csharp
public class Employee
{
    public Datetime sWorkDate { get; set; } // what the heck is this
    public Datetime modTime { get; set; } // same here
}
```

**Good:**

```csharp
public class Employee
{
    public Datetime StartWorkingDate { get; set; }
    public Datetime ModificationTime { get; set; }
}
```

**[⬆ Back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use Camelcase notation</b></summary>

Use [Camelcase Notation](https://en.wikipedia.org/wiki/Camel_case) for variable and method paramaters.

**Bad:**

```csharp
var employeephone;

public double CalculateSalary(int workingdays, int workinghours)
{
    // some logic
}
```

**Good:**

```csharp
var employeePhone;

public double CalculateSalary(int workingDays, int workingHours)
{
    // some logic
}
```

**[⬆ Back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use domain name</b></summary>

People who read your code are also programmers. Naming things right will help everyone be on the same page. We don't want to take time to explain to everyone what a variable or function is for.

**Good**

```csharp
public class SingleObject
{
    // create an object of SingleObject
    private static SingleObject _instance = new SingleObject();

    // make the constructor private so that this class cannot be instantiated
    private SingleObject() {}

    // get the only object available
    public static SingleObject GetInstance()
    {
        return _instance;
    }

    public string ShowMessage()
    {
        return "Hello World!";
    }
}

public static void main(String[] args)
{
    // illegal construct
    // var object = new SingleObject();

    // Get the only object available
    var singletonObject = SingleObject.GetInstance();

    // show the message
    singletonObject.ShowMessage();
}
```

**[⬆ Back to top](#table-of-contents)**

</details>

## Variables

<details>
  <summary><b>Avoid nesting too deeply and return early</b></summary>

Too many if else statements can make the code hard to follow. **Explicit is better than implicit**.

**Bad:**

```csharp
public bool IsShopOpen(string day)
{
    if (!string.IsNullOrEmpty(day))
    {
        day = day.ToLower();
        if (day == "friday")
        {
            return true;
        }
        else if (day == "saturday")
        {
            return true;
        }
        else if (day == "sunday")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }

}
```

**Good:**

```csharp
public bool IsShopOpen(string day)
{
    if (string.IsNullOrEmpty(day))
    {
        return false;
    }

    var openingDays = new[] { "friday", "saturday", "sunday" };
    return openingDays.Any(d => d == day.ToLower());
}
```

**Bad:**

```csharp
public long Fibonacci(int n)
{
    if (n < 50)
    {
        if (n != 0)
        {
            if (n != 1)
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
            else
            {
                return 1;
            }
        }
        else
        {
            return 0;
        }
    }
    else
    {
        throw new System.Exception("Not supported");
    }
}
```

**Good:**

```csharp
public long Fibonacci(int n)
{
    if (n == 0)
    {
        return 0;
    }

    if (n == 1)
    {
        return 1;
    }

    if (n > 50)
    {
        throw new System.Exception("Not supported");
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Avoid mental mapping</b></summary>

Don’t force the reader of your code to translate what the variable means. **Explicit is better than implicit**.

**Bad:**

```csharp
var l = new[] { "Austin", "New York", "San Francisco" };

for (var i = 0; i < l.Count(); i++)
{
    var li = l[i];
    DoStuff();
    DoSomeOtherStuff();

    // ...
    // ...
    // ...
    // Wait, what is `li` for again?
    Dispatch(li);
}
```

**Good:**

```csharp
var locations = new[] { "Austin", "New York", "San Francisco" };

foreach (var location in locations)
{
    DoStuff();
    DoSomeOtherStuff();

    // ...
    // ...
    // ...
    Dispatch(location);
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Avoid magic string</b></summary>

Magic strings are string values that are specified directly within application code that have an impact on the application’s behavior. Frequently, such strings will end up being duplicated within the system, and since they cannot automatically be updated using refactoring tools, they become a common source of bugs when changes are made to some strings but not others.

**Bad**

```csharp
if (userRole == "Admin")
{
    // logic in here
}
```

**Good**

```csharp
const string ADMIN_ROLE = "Admin"
if (userRole == ADMIN_ROLE)
{
    // logic in here
}
```

Using this we only have to change in centralize place and others will adapt it.

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Don't add unneeded context</b></summary>

If your class/object name tells you something, don't repeat that in your variable name.

**Bad:**

```csharp
public class Car
{
    public string CarMake { get; set; }
    public string CarModel { get; set; }
    public string CarColor { get; set; }

    //...
}
```

**Good:**

```csharp
public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }

    //...
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use meaningful and pronounceable variable names</b></summary>

**Bad:**

```csharp
var ymdstr = DateTime.UtcNow.ToString("MMMM dd, yyyy");
```

**Good:**

```csharp
var currentDate = DateTime.UtcNow.ToString("MMMM dd, yyyy");
```

**[⬆ Back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use the same vocabulary for the same type of variable</b></summary>

**Bad:**

```csharp
GetUserInfo();
GetUserData();
GetUserRecord();
GetUserProfile();
```

**Good:**

```csharp
GetUser();
```

**[⬆ Back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use searchable names (part 1)</b></summary>

We will read more code than we will ever write. It's important that the code we do write is readable and searchable. By _not_ naming variables that end up being meaningful for understanding our program, we hurt our readers. Make your names searchable.

**Bad:**

```csharp
// What the heck is data for?
var data = new { Name = "John", Age = 42 };

var stream1 = new MemoryStream();
var ser1 = new DataContractJsonSerializer(typeof(object));
ser1.WriteObject(stream1, data);

stream1.Position = 0;
var sr1 = new StreamReader(stream1);
Console.Write("JSON form of Data object: ");
Console.WriteLine(sr1.ReadToEnd());
```

**Good:**

```csharp
var person = new Person
{
    Name = "John",
    Age = 42
};

var stream2 = new MemoryStream();
var ser2 = new DataContractJsonSerializer(typeof(Person));
ser2.WriteObject(stream2, data);

stream2.Position = 0;
var sr2 = new StreamReader(stream2);
Console.Write("JSON form of Data object: ");
Console.WriteLine(sr2.ReadToEnd());
```

**[⬆ Back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use searchable names (part 2)</b></summary>

**Bad:**

```csharp
var data = new { Name = "John", Age = 42, PersonAccess = 4};

// What the heck is 4 for?
if (data.PersonAccess == 4)
{
    // do edit ...
}
```

**Good:**

```csharp
public enum PersonAccess : int
{
    ACCESS_READ = 1,
    ACCESS_CREATE = 2,
    ACCESS_UPDATE = 4,
    ACCESS_DELETE = 8
}

var person = new Person
{
    Name = "John",
    Age = 42,
    PersonAccess= PersonAccess.ACCESS_CREATE
};

if (person.PersonAccess == PersonAccess.ACCESS_UPDATE)
{
    // do edit ...
}
```

**[⬆ Back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use explanatory variables</b></summary>

**Bad:**

```csharp
const string Address = "One Infinite Loop, Cupertino 95014";
var cityZipCodeRegex = @"/^[^,\]+[,\\s]+(.+?)\s*(\d{5})?$/";
var matches = Regex.Matches(Address, cityZipCodeRegex);
if (matches[0].Success == true && matches[1].Success == true)
{
    SaveCityZipCode(matches[0].Value, matches[1].Value);
}
```

**Good:**

Decrease dependence on regex by naming subpatterns.

```csharp
const string Address = "One Infinite Loop, Cupertino 95014";
var cityZipCodeWithGroupRegex = @"/^[^,\]+[,\\s]+(?<city>.+?)\s*(?<zipCode>\d{5})?$/";
var matchesWithGroup = Regex.Match(Address, cityZipCodeWithGroupRegex);
var cityGroup = matchesWithGroup.Groups["city"];
var zipCodeGroup = matchesWithGroup.Groups["zipCode"];
if(cityGroup.Success == true && zipCodeGroup.Success == true)
{
    SaveCityZipCode(cityGroup.Value, zipCodeGroup.Value);
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use default arguments instead of short circuiting or conditionals</b></summary>

**Not good:**

This is not good because `breweryName` can be `NULL`.

This opinion is more understandable than the previous version, but it better controls the value of the variable.

```csharp
public void CreateMicrobrewery(string name = null)
{
    var breweryName = !string.IsNullOrEmpty(name) ? name : "Hipster Brew Co.";
    // ...
}
```

**Good:**

```csharp
public void CreateMicrobrewery(string breweryName = "Hipster Brew Co.")
{
    // ...
}
```

**[⬆ back to top](#table-of-contents)**

</details>

## Functions

<details>
  <summary><b>Avoid side effects</b></summary>

A function produces a side effect if it does anything other than take a value in and return another value or values. A side effect could be writing to a file, modifying some global variable, or accidentally wiring all your money to a stranger.

Now, you do need to have side effects in a program on occasion. Like the previous example, you might need to write to a file. What you want to do is to centralize where you are doing this. Don't have several functions and classes that write to a particular file. Have one service that does it. One and only one.

The main point is to avoid common pitfalls like sharing state between objects without any structure, using mutable data types that can be written to by anything, and not centralizing where your side effects occur. If you can do this, you will be happier
than the vast majority of other programmers.

**Bad:**

```csharp
// Global variable referenced by following function.
// If we had another function that used this name, now it'd be an array and it could break it.
var name = "Ryan McDermott";

public void SplitAndEnrichFullName()
{
    var temp = name.Split(" ");
    name = $"His first name is {temp[0]}, and his last name is {temp[1]}"; // side effect
}

SplitAndEnrichFullName();

Console.WriteLine(name); // His first name is Ryan, and his last name is McDermott
```

**Good:**

```csharp
public string SplitAndEnrichFullName(string name)
{
    var temp = name.Split(" ");
    return $"His first name is {temp[0]}, and his last name is {temp[1]}";
}

var name = "Ryan McDermott";
var fullName = SplitAndEnrichFullName(name);

Console.WriteLine(name); // Ryan McDermott
Console.WriteLine(fullName); // His first name is Ryan, and his last name is McDermott
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Avoid negative conditionals</b></summary>

**Bad:**

```csharp
public bool IsDOMNodeNotPresent(string node)
{
    // ...
}

if (!IsDOMNodeNotPresent(node))
{
    // ...
}
```

**Good:**

```csharp
public bool IsDOMNodePresent(string node)
{
    // ...
}

if (IsDOMNodePresent(node))
{
    // ...
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Avoid conditionals</b></summary>

This seems like an impossible task. Upon first hearing this, most people say, "how am I supposed to do anything without an `if` statement?" The answer is that you can use polymorphism to achieve the same task in many cases. The second question is usually, "well that's great but why would I want to do that?" The answer is a previous clean code concept we learned: a function should only do
one thing. When you have classes and functions that have `if` statements, you are telling your user that your function does more than one thing. Remember, just do one thing.

**Bad:**

```csharp
class Airplane
{
    // ...

    public double GetCruisingAltitude()
    {
        switch (_type)
        {
            case '777':
                return GetMaxAltitude() - GetPassengerCount();
            case 'Air Force One':
                return GetMaxAltitude();
            case 'Cessna':
                return GetMaxAltitude() - GetFuelExpenditure();
        }
    }
}
```

**Good:**

```csharp
interface IAirplane
{
    // ...

    double GetCruisingAltitude();
}

class Boeing777 : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude() - GetPassengerCount();
    }
}

class AirForceOne : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude();
    }
}

class Cessna : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude() - GetFuelExpenditure();
    }
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Avoid type-checking (part 1)</b></summary>

**Bad:**

```csharp
public Path TravelToTehran(object vehicle)
{
    if (vehicle.GetType() == typeof(Bicycle))
    {
        (vehicle as Bicycle).PeddleTo(new Location("texas"));
    }
    else if (vehicle.GetType() == typeof(Car))
    {
        (vehicle as Car).DriveTo(new Location("texas"));
    }
}
```

**Good:**

```csharp
public Path TravelToTexas(Traveler vehicle)
{
    vehicle.TravelTo(new Location("texas"));
}
```

or

```csharp
// pattern matching
public Path TravelToTexas(object vehicle)
{
    if (vehicle is Bicycle bicycle)
    {
        bicycle.PeddleTo(new Location("texas"));
    }
    else if (vehicle is Car car)
    {
        car.DriveTo(new Location("texas"));
    }
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Avoid type-checking (part 2)</b></summary>

**Bad:**

```csharp
public int Combine(dynamic val1, dynamic val2)
{
    int value;
    if (!int.TryParse(val1, out value) || !int.TryParse(val2, out value))
    {
        throw new Exception('Must be of type Number');
    }

    return val1 + val2;
}
```

**Good:**

```csharp
public int Combine(int val1, int val2)
{
    return val1 + val2;
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Avoid flags in method parameters</b></summary>

A flag indicates that the method has more than one responsibility. It is best if the method only has a single responsibility. Split the method into two if a boolean parameter adds multiple responsibilities to the method.

**Bad:**

```csharp
public void CreateFile(string name, bool temp = false)
{
    if (temp)
    {
        Touch("./temp/" + name);
    }
    else
    {
        Touch(name);
    }
}
```

**Good:**

```csharp
public void CreateFile(string name)
{
    Touch(name);
}

public void CreateTempFile(string name)
{
    Touch("./temp/"  + name);
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Don't write to global functions</b></summary>

Polluting globals is a bad practice in many languages because you could clash with another library and the user of your API would be none-the-wiser until they get an exception in production. Let's think about an example: what if you wanted to have configuration array.
You could write global function like `Config()`, but it could clash with another library that tried to do the same thing.

**Bad:**

```csharp
public Dictionary<string, string> Config()
{
    return new Dictionary<string,string>(){
        ["foo"] = "bar"
    };
}
```

**Good:**

```csharp
class Configuration
{
    private Dictionary<string, string> _configuration;

    public Configuration(Dictionary<string, string> configuration)
    {
        _configuration = configuration;
    }

    public string[] Get(string key)
    {
        return _configuration.ContainsKey(key) ? _configuration[key] : null;
    }
}
```

Load configuration and create instance of `Configuration` class

```csharp
var configuration = new Configuration(new Dictionary<string, string>() {
    ["foo"] = "bar"
});
```

And now you must use instance of `Configuration` in your application.

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Don't use a Singleton pattern</b></summary>

Singleton is an [anti-pattern](https://en.wikipedia.org/wiki/Singleton_pattern). Paraphrased from Brian Button:

1. They are generally used as a **global instance**, why is that so bad? Because **you hide the dependencies** of your application in your code, instead of exposing them through the interfaces. Making something global to avoid passing it around is a [code smell](https://en.wikipedia.org/wiki/Code_smell).
2. They violate the [single responsibility principle](#single-responsibility-principle-srp): by virtue of the fact that **they control their own creation and lifecycle**.
3. They inherently cause code to be tightly [coupled](https://en.wikipedia.org/wiki/Coupling_%28computer_programming%29). This makes faking them out under **test rather difficult** in many cases.
4. They carry state around for the lifetime of the application. Another hit to testing since **you can end up with a situation where tests need to be ordered** which is a big no for unit tests. Why? Because each unit test should be independent from the other.

There is also very good thoughts by [Misko Hevery](http://misko.hevery.com/about/) about the [root of problem](http://misko.hevery.com/2008/08/25/root-cause-of-singletons/).

**Bad:**

```csharp
class DBConnection
{
    private static DBConnection _instance;

    private DBConnection()
    {
        // ...
    }

    public static GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DBConnection();
        }

        return _instance;
    }

    // ...
}

var singleton = DBConnection.GetInstance();
```

**Good:**

```csharp
class DBConnection
{
    public DBConnection(IOptions<DbConnectionOption> options)
    {
        // ...
    }

    // ...
}
```

Create instance of `DBConnection` class and configure it with [Option pattern](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-2.1).

```csharp
var options = <resolve from IOC>;
var connection = new DBConnection(options);
```

And now you must use instance of `DBConnection` in your application.

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Function arguments (2 or fewer ideally)</b></summary>

Limiting the amount of function parameters is incredibly important because it makes testing your function easier. Having more than three leads to a combinatorial explosion where you have to test tons of different cases with each separate argument.

Zero arguments is the ideal case. One or two arguments is ok, and three should be avoided. Anything more than that should be consolidated. Usually, if you have more than two arguments then your function is trying to do too much. In cases where it's not, most of the time a higher-level object will suffice as an argument.

**Bad:**

```csharp
public void CreateMenu(string title, string body, string buttonText, bool cancellable)
{
    // ...
}
```

**Good:**

```csharp
public class MenuConfig
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string ButtonText { get; set; }
    public bool Cancellable { get; set; }
}

var config = new MenuConfig
{
    Title = "Foo",
    Body = "Bar",
    ButtonText = "Baz",
    Cancellable = true
};

public void CreateMenu(MenuConfig config)
{
    // ...
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Functions should do one thing</b></summary>

This is by far the most important rule in software engineering. When functions do more than one thing, they are harder to compose, test, and reason about. When you can isolate a function to just one action, they can be refactored easily and your code will read much
cleaner. If you take nothing else away from this guide other than this, you'll be ahead of many developers.

**Bad:**

```csharp
public void SendEmailToListOfClients(string[] clients)
{
    foreach (var client in clients)
    {
        var clientRecord = db.Find(client);
        if (clientRecord.IsActive())
        {
            Email(client);
        }
    }
}
```

**Good:**

```csharp
public void SendEmailToListOfClients(string[] clients)
{
    var activeClients = GetActiveClients(clients);
    // Do some logic
}

public List<Client> GetActiveClients(string[] clients)
{
    return db.Find(clients).Where(s => s.Status == "Active");
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Function names should say what they do</b></summary>

**Bad:**

```csharp
public class Email
{
    //...

    public void Handle()
    {
        SendMail(this._to, this._subject, this._body);
    }
}

var message = new Email(...);
// What is this? A handle for the message? Are we writing to a file now?
message.Handle();
```

**Good:**

```csharp
public class Email
{
    //...

    public void Send()
    {
        SendMail(this._to, this._subject, this._body);
    }
}

var message = new Email(...);
// Clear and obvious
message.Send();
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Functions should only be one level of abstraction</b></summary>

> Not finished yet

When you have more than one level of abstraction your function is usually doing too much. Splitting up functions leads to reusability and easier testing.

**Bad:**

```csharp
public string ParseBetterJSAlternative(string code)
{
    var regexes = [
        // ...
    ];

    var statements = explode(" ", code);
    var tokens = new string[] {};
    foreach (var regex in regexes)
    {
        foreach (var statement in statements)
        {
            // ...
        }
    }

    var ast = new string[] {};
    foreach (var token in tokens)
    {
        // lex...
    }

    foreach (var node in ast)
    {
        // parse...
    }
}
```

**Bad too:**

We have carried out some of the functionality, but the `ParseBetterJSAlternative()` function is still very complex and not testable.

```csharp
public string Tokenize(string code)
{
    var regexes = new string[]
    {
        // ...
    };

    var statements = explode(" ", code);
    var tokens = new string[] {};
    foreach (var regex in regexes)
    {
        foreach (var statement in statements)
        {
            tokens[] = /* ... */;
        }
    }

    return tokens;
}

public string Lexer(string[] tokens)
{
    var ast = new string[] {};
    foreach (var token in tokens)
    {
        ast[] = /* ... */;
    }

    return ast;
}

public string ParseBetterJSAlternative(string code)
{
    var tokens = Tokenize(code);
    var ast = Lexer(tokens);
    foreach (var node in ast)
    {
        // parse...
    }
}
```

**Good:**

The best solution is move out the dependencies of `ParseBetterJSAlternative()` function.

```csharp
class Tokenizer
{
    public string Tokenize(string code)
    {
        var regexes = new string[] {
            // ...
        };

        var statements = explode(" ", code);
        var tokens = new string[] {};
        foreach (var regex in regexes)
        {
            foreach (var statement in statements)
            {
                tokens[] = /* ... */;
            }
        }

        return tokens;
    }
}

class Lexer
{
    public string Lexify(string[] tokens)
    {
        var ast = new[] {};
        foreach (var token in tokens)
        {
            ast[] = /* ... */;
        }

        return ast;
    }
}

class BetterJSAlternative
{
    private string _tokenizer;
    private string _lexer;

    public BetterJSAlternative(Tokenizer tokenizer, Lexer lexer)
    {
        _tokenizer = tokenizer;
        _lexer = lexer;
    }

    public string Parse(string code)
    {
        var tokens = _tokenizer.Tokenize(code);
        var ast = _lexer.Lexify(tokens);
        foreach (var node in ast)
        {
            // parse...
        }
    }
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Function callers and callees should be close</b></summary>

If a function calls another, keep those functions vertically close in the source file. Ideally, keep the caller right above the callee. We tend to read code from top-to-bottom, like a newspaper. Because of this, make your code read that way.

**Bad:**

```csharp
class PerformanceReview
{
    private readonly Employee _employee;

    public PerformanceReview(Employee employee)
    {
        _employee = employee;
    }

    private IEnumerable<PeersData> LookupPeers()
    {
        return db.lookup(_employee, 'peers');
    }

    private ManagerData LookupManager()
    {
        return db.lookup(_employee, 'manager');
    }

    private IEnumerable<PeerReviews> GetPeerReviews()
    {
        var peers = LookupPeers();
        // ...
    }

    public PerfReviewData PerfReview()
    {
        GetPeerReviews();
        GetManagerReview();
        GetSelfReview();
    }

    public ManagerData GetManagerReview()
    {
        var manager = LookupManager();
    }

    public EmployeeData GetSelfReview()
    {
        // ...
    }
}

var  review = new PerformanceReview(employee);
review.PerfReview();
```

**Good:**

```csharp
class PerformanceReview
{
    private readonly Employee _employee;

    public PerformanceReview(Employee employee)
    {
        _employee = employee;
    }

    public PerfReviewData PerfReview()
    {
        GetPeerReviews();
        GetManagerReview();
        GetSelfReview();
    }

    private IEnumerable<PeerReviews> GetPeerReviews()
    {
        var peers = LookupPeers();
        // ...
    }

    private IEnumerable<PeersData> LookupPeers()
    {
        return db.lookup(_employee, 'peers');
    }

    private ManagerData GetManagerReview()
    {
        var manager = LookupManager();
        return manager;
    }

    private ManagerData LookupManager()
    {
        return db.lookup(_employee, 'manager');
    }

    private EmployeeData GetSelfReview()
    {
        // ...
    }
}

var review = new PerformanceReview(employee);
review.PerfReview();
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Encapsulate conditionals</b></summary>

**Bad:**

```csharp
if (article.state == "published")
{
    // ...
}
```

**Good:**

```csharp
if (article.IsPublished())
{
    // ...
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Remove dead code</b></summary>

Dead code is just as bad as duplicate code. There's no reason to keep it in your codebase. If it's not being called, get rid of it! It will still be safe in your version history if you still need it.

**Bad:**

```csharp
public void OldRequestModule(string url)
{
    // ...
}

public void NewRequestModule(string url)
{
    // ...
}

var request = NewRequestModule(requestUrl);
InventoryTracker("apples", request, "www.inventory-awesome.io");
```

**Good:**

```csharp
public void RequestModule(string url)
{
    // ...
}

var request = RequestModule(requestUrl);
InventoryTracker("apples", request, "www.inventory-awesome.io");
```

**[⬆ back to top](#table-of-contents)**

</details>

## Objects and Data Structures

<details>
  <summary><b>Use getters and setters</b></summary>

In C#  you can set `public`, `protected` and `private` keywords for methods.
Using it, you can control properties modification on an object.

- When you want to do more beyond getting an object property, you don't have to look up and change every accessor in your codebase.
- Makes adding validation simple when doing a `set`.
- Encapsulates the internal representation.
- Easy to add logging and error handling when getting and setting.
- Inheriting this class, you can override default functionality.
- You can lazy load your object's properties, let's say getting it from a server.

Additionally, this is part of Open/Closed principle, from object-oriented design principles.

**Bad:**

```csharp
class BankAccount
{
    public double Balance = 1000;
}

var bankAccount = new BankAccount();

// Fake buy shoes...
bankAccount.Balance -= 100;
```

**Good:**

```csharp
class BankAccount
{
    private double _balance = 0.0D;

    pubic double Balance {
        get {
            return _balance;
        }
    }

    public BankAccount(balance = 1000)
    {
       _balance = balance;
    }

    public void WithdrawBalance(int amount)
    {
        if (amount > _balance)
        {
            throw new Exception('Amount greater than available balance.');
        }

        _balance -= amount;
    }

    public void DepositBalance(int amount)
    {
        _balance += amount;
    }
}

var bankAccount = new BankAccount();

// Buy shoes...
bankAccount.WithdrawBalance(price);

// Get balance
balance = bankAccount.Balance;
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Make objects have private/protected members</b></summary>

**Bad:**

```csharp
class Employee
{
    public string Name { get; set; }

    public Employee(string name)
    {
        Name = name;
    }
}

var employee = new Employee("John Doe");
Console.WriteLine(employee.Name); // Employee name: John Doe
```

**Good:**

```csharp
class Employee
{
    public string Name { get; }

    public Employee(string name)
    {
        Name = name;
    }
}

var employee = new Employee("John Doe");
Console.WriteLine(employee.Name); // Employee name: John Doe
```

**[⬆ back to top](#table-of-contents)**

</details>

## Classes

<details>
  <summary><b>Use method chaining</b></summary>

This pattern is very useful and commonly used in many libraries. It allows your code to be expressive, and less verbose.
For that reason, use method chaining and take a look at how clean your code will be.

**Good:**

```csharp
public static class ListExtensions
{
    public static List<T> FluentAdd<T>(this List<T> list, T item)
    {
        list.Add(item);
        return list;
    }

    public static List<T> FluentClear<T>(this List<T> list)
    {
        list.Clear();
        return list;
    }

    public static List<T> FluentForEach<T>(this List<T> list, Action<T> action)
    {
        list.ForEach(action);
        return list;
    }

    public static List<T> FluentInsert<T>(this List<T> list, int index, T item)
    {
        list.Insert(index, item);
        return list;
    }

    public static List<T> FluentRemoveAt<T>(this List<T> list, int index)
    {
        list.RemoveAt(index);
        return list;
    }

    public static List<T> FluentReverse<T>(this List<T> list)
    {
        list.Reverse();
        return list;
    }
}

internal static void ListFluentExtensions()
{
    var list = new List<int>() { 1, 2, 3, 4, 5 }
        .FluentAdd(1)
        .FluentInsert(0, 0)
        .FluentRemoveAt(1)
        .FluentReverse()
        .FluentForEach(value => value.WriteLine())
        .FluentClear();
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Prefer composition over inheritance</b></summary>

As stated famously in [_Design Patterns_](https://en.wikipedia.org/wiki/Design_Patterns) by the Gang of Four,
you should prefer composition over inheritance where you can. There are lots of good reasons to use inheritance and lots of good reasons to use composition.

The main point for this maxim is that if your mind instinctively goes for inheritance, try to think if composition could model your problem better. In some cases it can.

You might be wondering then, "when should I use inheritance?" It
depends on your problem at hand, but this is a decent list of when inheritance makes more sense than composition:

1. Your inheritance represents an "is-a" relationship and not a "has-a" relationship (Human->Animal vs. User->UserDetails).
2. You can reuse code from the base classes (Humans can move like all animals).
3. You want to make global changes to derived classes by changing a base class (Change the caloric expenditure of all animals when they move).

**Bad:**

```csharp
class Employee
{
    private string Name { get; set; }
    private string Email { get; set; }

    public Employee(string name, string email)
    {
        Name = name;
        Email = email;
    }

    // ...
}

// Bad because Employees "have" tax data.
// EmployeeTaxData is not a type of Employee

class EmployeeTaxData : Employee
{
    private string Name { get; }
    private string Email { get; }

    public EmployeeTaxData(string name, string email, string ssn, string salary)
    {
         // ...
    }

    // ...
}
```

**Good:**

```csharp
class EmployeeTaxData
{
    public string Ssn { get; }
    public string Salary { get; }

    public EmployeeTaxData(string ssn, string salary)
    {
        Ssn = ssn;
        Salary = salary;
    }

    // ...
}

class Employee
{
    public string Name { get; }
    public string Email { get; }
    public EmployeeTaxData TaxData { get; }

    public Employee(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void SetTax(string ssn, double salary)
    {
        TaxData = new EmployeeTaxData(ssn, salary);
    }

    // ...
}
```

**[⬆ back to top](#table-of-contents)**

</details>

## SOLID

<details>
  <summary><b>What is SOLID?</b></summary>

**SOLID** is the mnemonic acronym introduced by Michael Feathers for the first five principles named by Robert Martin, which meant five basic principles of object-oriented programming and design.

- [S: Single Responsibility Principle (SRP)](#single-responsibility-principle-srp)
- [O: Open/Closed Principle (OCP)](#openclosed-principle-ocp)
- [L: Liskov Substitution Principle (LSP)](#liskov-substitution-principle-lsp)
- [I: Interface Segregation Principle (ISP)](#interface-segregation-principle-isp)
- [D: Dependency Inversion Principle (DIP)](#dependency-inversion-principle-dip)

</details>

<details>
  <summary><b>Single Responsibility Principle (SRP)</b></summary>

As stated in Clean Code, "There should never be more than one reason for a class to change". It's tempting to jam-pack a class with a lot of functionality, like when you can only take one suitcase on your flight. The issue with this is that your class won't be conceptually cohesive and it will give it many reasons to change. Minimizing the amount of times you need to change a class is important.

It's important because if too much functionality is in one class and you modify a piece of it, it can be difficult to understand how that will affect other dependent modules in your codebase.

**Bad:**

```csharp
class UserSettings
{
    private User User;

    public UserSettings(User user)
    {
        User = user;
    }

    public void ChangeSettings(Settings settings)
    {
        if (verifyCredentials())
        {
            // ...
        }
    }

    private bool VerifyCredentials()
    {
        // ...
    }
}
```

**Good:**

```csharp
class UserAuth
{
    private User User;

    public UserAuth(User user)
    {
        User = user;
    }

    public bool VerifyCredentials()
    {
        // ...
    }
}

class UserSettings
{
    private User User;
    private UserAuth Auth;

    public UserSettings(User user)
    {
        User = user;
        Auth = new UserAuth(user);
    }

    public void ChangeSettings(Settings settings)
    {
        if (Auth.VerifyCredentials())
        {
            // ...
        }
    }
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Open/Closed Principle (OCP)</b></summary>

As stated by Bertrand Meyer, "software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification." What does that mean though? This principle basically states that you should allow users to add new functionalities without changing existing code.

**Bad:**

```csharp
abstract class AdapterBase
{
    protected string Name;

    public string GetName()
    {
        return Name;
    }
}

class AjaxAdapter : AdapterBase
{
    public AjaxAdapter()
    {
        Name = "ajaxAdapter";
    }
}

class NodeAdapter : AdapterBase
{
    public NodeAdapter()
    {
        Name = "nodeAdapter";
    }
}

class HttpRequester : AdapterBase
{
    private readonly AdapterBase Adapter;

    public HttpRequester(AdapterBase adapter)
    {
        Adapter = adapter;
    }

    public bool Fetch(string url)
    {
        var adapterName = Adapter.GetName();

        if (adapterName == "ajaxAdapter")
        {
            return MakeAjaxCall(url);
        }
        else if (adapterName == "httpNodeAdapter")
        {
            return MakeHttpCall(url);
        }
    }

    private bool MakeAjaxCall(string url)
    {
        // request and return promise
    }

    private bool MakeHttpCall(string url)
    {
        // request and return promise
    }
}
```

**Good:**

```csharp
interface IAdapter
{
    bool Request(string url);
}

class AjaxAdapter : IAdapter
{
    public bool Request(string url)
    {
        // request and return promise
    }
}

class NodeAdapter : IAdapter
{
    public bool Request(string url)
    {
        // request and return promise
    }
}

class HttpRequester
{
    private readonly IAdapter Adapter;

    public HttpRequester(IAdapter adapter)
    {
        Adapter = adapter;
    }

    public bool Fetch(string url)
    {
        return Adapter.Request(url);
    }
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Liskov Substitution Principle (LSP)</b></summary>

This is a scary term for a very simple concept. It's formally defined as "If S is a subtype of T, then objects of type T may be replaced with objects of type S (i.e., objects of type S may substitute objects of type T) without altering any of the desirable properties of that program (correctness, task performed,
etc.)." That's an even scarier definition.

The best explanation for this is if you have a parent class and a child class, then the base class and child class can be used interchangeably without getting incorrect results. This might still be confusing, so let's take a look at the classic Square-Rectangle example. Mathematically, a square is a rectangle, but if you model it using the "is-a" relationship via inheritance, you quickly
get into trouble.

**Bad:**

```csharp
class Rectangle
{
    protected double Width = 0;
    protected double Height = 0;

    public Drawable Render(double area)
    {
        // ...
    }

    public void SetWidth(double width)
    {
        Width = width;
    }

    public void SetHeight(double height)
    {
        Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }
}

class Square : Rectangle
{
    public double SetWidth(double width)
    {
        Width = Height = width;
    }

    public double SetHeight(double height)
    {
        Width = Height = height;
    }
}

Drawable RenderLargeRectangles(Rectangle rectangles)
{
    foreach (rectangle in rectangles)
    {
        rectangle.SetWidth(4);
        rectangle.SetHeight(5);
        var area = rectangle.GetArea(); // BAD: Will return 25 for Square. Should be 20.
        rectangle.Render(area);
    }
}

var rectangles = new[] { new Rectangle(), new Rectangle(), new Square() };
RenderLargeRectangles(rectangles);
```

**Good:**

```csharp
abstract class ShapeBase
{
    protected double Width = 0;
    protected double Height = 0;

    abstract public double GetArea();

    public Drawable Render(double area)
    {
        // ...
    }
}

class Rectangle : ShapeBase
{
    public void SetWidth(double width)
    {
        Width = width;
    }

    public void SetHeight(double height)
    {
        Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }
}

class Square : ShapeBase
{
    private double Length = 0;

    public double SetLength(double length)
    {
        Length = length;
    }

    public double GetArea()
    {
        return Math.Pow(Length, 2);
    }
}

Drawable RenderLargeRectangles(Rectangle rectangles)
{
    foreach (rectangle in rectangles)
    {
        if (rectangle is Square)
        {
            rectangle.SetLength(5);
        }
        else if (rectangle is Rectangle)
        {
            rectangle.SetWidth(4);
            rectangle.SetHeight(5);
        }

        var area = rectangle.GetArea();
        rectangle.Render(area);
    }
}

var shapes = new[] { new Rectangle(), new Rectangle(), new Square() };
RenderLargeRectangles(shapes);
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Interface Segregation Principle (ISP)</b></summary>

ISP states that "Clients should not be forced to depend upon interfaces that they do not use."

A good example to look at that demonstrates this principle is for
classes that require large settings objects. Not requiring clients to setup huge amounts of options is beneficial, because most of the time they won't need all of the settings. Making them optional helps prevent having a "fat interface".

**Bad:**

```csharp
public interface IEmployee
{
    void Work();
    void Eat();
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }

    public void Eat()
    {
        // ...... eating in lunch break
    }
}

public class Robot : IEmployee
{
    public void Work()
    {
        //.... working much more
    }

    public void Eat()
    {
        //.... robot can't eat, but it must implement this method
    }
}
```

**Good:**

Not every worker is an employee, but every employee is an worker.

```csharp
public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}

public interface IEmployee : IFeedable, IWorkable
{
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }

    public void Eat()
    {
        //.... eating in lunch break
    }
}

// robot can only work
public class Robot : IWorkable
{
    public void Work()
    {
        // ....working
    }
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Dependency Inversion Principle (DIP)</b></summary>

This principle states two essential things:

1. High-level modules should not depend on low-level modules. Both should depend on abstractions.
2. Abstractions should not depend upon details. Details should depend on abstractions.

This can be hard to understand at first, but if you've worked with .NET/.NET Core framework, you've seen an implementation of this principle in the form of [Dependency Injection](https://martinfowler.com/articles/injection.html) (DI). While they are not identical concepts, DIP keeps high-level modules from knowing the details of its low-level modules and setting them up.
It can accomplish this through DI. A huge benefit of this is that it reduces the coupling between modules. Coupling is a very bad development pattern because it makes your code hard to refactor.

**Bad:**

```csharp
public abstract class EmployeeBase
{
    protected virtual void Work()
    {
        // ....working
    }
}

public class Human : EmployeeBase
{
    public override void Work()
    {
        //.... working much more
    }
}

public class Robot : EmployeeBase
{
    public override void Work()
    {
        //.... working much, much more
    }
}

public class Manager
{
    private readonly Robot _robot;
    private readonly Human _human;

    public Manager(Robot robot, Human human)
    {
        _robot = robot;
        _human = human;
    }

    public void Manage()
    {
        _robot.Work();
        _human.Work();
    }
}
```

**Good:**

```csharp
public interface IEmployee
{
    void Work();
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }
}

public class Robot : IEmployee
{
    public void Work()
    {
        //.... working much more
    }
}

public class Manager
{
    private readonly IEnumerable<IEmployee> _employees;

    public Manager(IEnumerable<IEmployee> employees)
    {
        _employees = employees;
    }

    public void Manage()
    {
        foreach (var employee in _employees)
        {
            _employee.Work();
        }
    }
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Don’t repeat yourself (DRY)</b></summary>

Try to observe the [DRY](https://en.wikipedia.org/wiki/Don%27t_repeat_yourself) principle.

Do your absolute best to avoid duplicate code. Duplicate code is bad because it means that there's more than one place to alter something if you need to change some logic.

Imagine if you run a restaurant and you keep track of your inventory: all your tomatoes, onions, garlic, spices, etc. If you have multiple lists that you keep this on, then all have to be updated when you serve a dish with tomatoes in them. If you only have one list, there's only one place to update!

Oftentimes you have duplicate code because you have two or more slightly different things, that share a lot in common, but their differences force you to have two or more separate functions that do much of the same things. Removing duplicate code means creating an abstraction that can handle this set of different things with just one function/module/class.

Getting the abstraction right is critical, that's why you should follow the SOLID principles laid out in the [Classes](#classes) section. Bad abstractions can be worse than duplicate code, so be careful! Having said this, if you can make a good abstraction, do it! Don't repeat yourself, otherwise you'll find yourself updating multiple places anytime you want to change one thing.

**Bad:**

```csharp
public List<EmployeeData> ShowDeveloperList(Developers developers)
{
    foreach (var developers in developer)
    {
        var expectedSalary = developer.CalculateExpectedSalary();
        var experience = developer.GetExperience();
        var githubLink = developer.GetGithubLink();
        var data = new[] {
            expectedSalary,
            experience,
            githubLink
        };

        Render(data);
    }
}

public List<ManagerData> ShowManagerList(Manager managers)
{
    foreach (var manager in managers)
    {
        var expectedSalary = manager.CalculateExpectedSalary();
        var experience = manager.GetExperience();
        var githubLink = manager.GetGithubLink();
        var data =
        new[] {
            expectedSalary,
            experience,
            githubLink
        };

        render(data);
    }
}
```

**Good:**

```csharp
public List<EmployeeData> ShowList(Employee employees)
{
    foreach (var employee in employees)
    {
        var expectedSalary = employees.CalculateExpectedSalary();
        var experience = employees.GetExperience();
        var githubLink = employees.GetGithubLink();
        var data =
        new[] {
            expectedSalary,
            experience,
            githubLink
        };

        render(data);
    }
}
```

**Very good:**

It is better to use a compact version of the code.

```csharp
public List<EmployeeData> ShowList(Employee employees)
{
    foreach (var employee in employees)
    {
        render(new[] {
            employee.CalculateExpectedSalary(),
            employee.GetExperience(),
            employee.GetGithubLink()
        });
    }
}
```

**[⬆ back to top](#table-of-contents)**

</details>

## Concurrency

<details>
  <summary><b>Use Async/Await</b></summary>

**Summary of Asynchronous Programming Guidelines**

| Name              | Description                                       | Exceptions                      |
| ----------------- | ------------------------------------------------- | ------------------------------- |
| Avoid async void  | Prefer async Task methods over async void methods | Event handlers                  |
| Async all the way | Don't mix blocking and async code                 | Console main method (C# <= 7.0) |
| Configure context | Use `ConfigureAwait(false)` when you can          | Methods that require con­text   |

**The Async Way of Doing Things**

| To Do This ...                           | Instead of This ...        | Use This             |
| ---------------------------------------- | -------------------------- | -------------------- |
| Retrieve the result of a background task | `Task.Wait or Task.Result` | `await`              |
| Wait for any task to complete            | `Task.WaitAny`             | `await Task.WhenAny` |
| Retrieve the results of multiple tasks   | `Task.WaitAll`             | `await Task.WhenAll` |
| Wait a period of time                    | `Thread.Sleep`             | `await Task.Delay`   |

**Best practice**

The async/await is the best for IO bound tasks (networking communication, database communication, http request, etc.) but it is not good to apply on computational bound tasks (traverse on the huge list, render a hugge image, etc.). Because it will release the holding thread to the thread pool and CPU/cores available will not involve to process those tasks. Therefore, we should avoid using Async/Await for computional bound tasks.

For dealing with computational bound tasks, prefer to use `Task.Factory.CreateNew` with `TaskCreationOptions` is `LongRunning`. It will start a new background thread to process a heavy computational bound task without release it back to the thread pool until the task being completed.

**Know Your Tools**

There's a lot to learn about async and await, and it's natural to get a little disoriented. Here's a quick reference of solutions to common problems.

**Solutions to Common Async Problems**

| Problem                                         | Solution                                                                          |
| ----------------------------------------------- | --------------------------------------------------------------------------------- |
| Create a task to execute code                   | `Task.Run` or `TaskFactory.StartNew` (not the `Task` constructor or `Task.Start`) |
| Create a task wrapper for an operation or event | `TaskFactory.FromAsync` or `TaskCompletionSource<T>`                              |
| Support cancellation                            | `CancellationTokenSource` and `CancellationToken`                                 |
| Report progress                                 | `IProgress<T>` and `Progress<T>`                                                  |
| Handle streams of data                          | TPL Dataflow or Reactive Extensions                                               |
| Synchronize access to a shared resource         | `SemaphoreSlim`                                                                   |
| Asynchronously initialize a resource            | `AsyncLazy<T>`                                                                    |
| Async-ready producer/consumer structures        | TPL Dataflow or `AsyncCollection<T>`                                              |

Read the [Task-based Asynchronous Pattern (TAP) document](http://www.microsoft.com/download/en/details.aspx?id=19957).
It is extremely well-written, and includes guidance on API design and the proper use of async/await (including cancellation and progress reporting).

There are many new await-friendly techniques that should be used instead of the old blocking techniques. If you have any of these Old examples in your new async code, you're Doing It Wrong(TM):

| Old                | New                                  | Description                                                   |
| ------------------ | ------------------------------------ | ------------------------------------------------------------- |
| `task.Wait`        | `await task`                         | Wait/await for a task to complete                             |
| `task.Result`      | `await task`                         | Get the result of a completed task                            |
| `Task.WaitAny`     | `await Task.WhenAny`                 | Wait/await for one of a collection of tasks to complete       |
| `Task.WaitAll`     | `await Task.WhenAll`                 | Wait/await for every one of a collection of tasks to complete |
| `Thread.Sleep`     | `await Task.Delay`                   | Wait/await for a period of time                               |
| `Task` constructor | `Task.Run` or `TaskFactory.StartNew` | Create a code-based task                                      |

> Source https://gist.github.com/jonlabelle/841146854b23b305b50fa5542f84b20c

**[⬆ back to top](#table-of-contents)**

</details>

## Error Handling

<details>
  <summary><b>Basic concept of error handling</b></summary>

Thrown errors are a good thing! They mean the runtime has successfully identified when something in your program has gone wrong and it's letting you know by stopping function execution on the current stack, killing the process (in .NET/.NET Core), and notifying you in the console with a stack trace.

</details>

<details>
  <summary><b>Don't use 'throw ex' in catch block</b></summary>

If you need to re-throw an exception after catching it, use just 'throw'
By using this, you will save the stack trace. But in the bad option below,
you will lost the stack trace.

**Bad:**

```csharp
try
{
    // Do something..
}
catch (Exception ex)
{
    // Any action something like roll-back or logging etc.
    throw ex;
}
```

**Good:**

```csharp
try
{
    // Do something..
}
catch (Exception ex)
{
    // Any action something like roll-back or logging etc.
    throw;
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Don't ignore caught errors</b></summary>

Doing nothing with a caught error doesn't give you the ability to ever fix or react to said error. Throwing the error isn't much better as often times it can get lost in a sea of things printed to the console. If you wrap any bit of code in a `try/catch` it means you think an error may occur there and therefore you should have a plan, or create a code path, for when it occurs.

**Bad:**

```csharp
try
{
    FunctionThatMightThrow();
}
catch (Exception ex)
{
    // silent exception
}
```

**Good:**

```csharp
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    NotifyUserOfError(error);

    // Another option
    ReportErrorToService(error);
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use multiple catch block instead of if conditions.</b></summary>

If you need to take action according to type of the exception,
you better use multiple catch block for exception handling.

**Bad:**

```csharp
try
{
    // Do something..
}
catch (Exception ex)
{

    if (ex is TaskCanceledException)
    {
        // Take action for TaskCanceledException
    }
    else if (ex is TaskSchedulerException)
    {
        // Take action for TaskSchedulerException
    }
}
```

**Good:**

```csharp
try
{
    // Do something..
}
catch (TaskCanceledException ex)
{
    // Take action for TaskCanceledException
}
catch (TaskSchedulerException ex)
{
    // Take action for TaskSchedulerException
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Keep exception stack trace when rethrowing exceptions</b></summary>

C# allows the exception to be rethrown in a catch block using the `throw` keyword. It is a bad practice to throw a caught exception using `throw e;`. This statement resets the stack trace. Instead use `throw;`. This will keep the stack trace and provide a deeper insight about the exception.
Another option is to use a custom exception. Simply instantiate a new exception and set its inner exception property to the caught exception with throw `new CustomException("some info", e);`. Adding information to an exception is a good practice as it will help with debugging. However, if the objective is to log an exception then use `throw;` to pass the buck to the caller.

**Bad:**

```csharp
try
{
    FunctionThatMightThrow();
}
catch (Exception ex)
{
    logger.LogInfo(ex);
    throw ex;
}
```

**Good:**

```csharp
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    logger.LogInfo(error);
    throw;
}
```

**Good:**

```csharp
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    logger.LogInfo(error);
    throw new CustomException(error);
}
```

**[⬆ back to top](#table-of-contents)**

</details>

## Formatting

<details>
  <summary><b>Uses <i>.editorconfig</i> file</b></summary>

**Bad:**

Has many code formatting styles in the project. For example, indent style is `space` and `tab` mixed in the project.

**Good:**

Define and maintain consistent code style in your codebase with the use of an `.editorconfig` file

```csharp
root = true

[*]
indent_style = space
indent_size = 2
end_of_line = lf
charset = utf-8
trim_trailing_whitespace = true
insert_final_newline = true

# C# files
[*.cs]
indent_size = 4
# New line preferences
csharp_new_line_before_open_brace = all
csharp_new_line_before_else = true
csharp_new_line_before_catch = true
csharp_new_line_before_finally = true
csharp_new_line_before_members_in_object_initializers = true
csharp_new_line_before_members_in_anonymous_types = true
csharp_new_line_within_query_expression_clauses = true

# Code files
[*.{cs,csx,vb,vbx}]
indent_size = 4

# Indentation preferences
csharp_indent_block_contents = true
csharp_indent_braces = false
csharp_indent_case_contents = true
csharp_indent_switch_labels = true
csharp_indent_labels = one_less_than_current

# avoid this. unless absolutely necessary
dotnet_style_qualification_for_field = false:suggestion
dotnet_style_qualification_for_property = false:suggestion
dotnet_style_qualification_for_method = false:suggestion
dotnet_style_qualification_for_event = false:suggestion

# only use var when it's obvious what the variable type is
# csharp_style_var_for_built_in_types = false:none
# csharp_style_var_when_type_is_apparent = false:none
# csharp_style_var_elsewhere = false:suggestion

# use language keywords instead of BCL types
dotnet_style_predefined_type_for_locals_parameters_members = true:suggestion
dotnet_style_predefined_type_for_member_access = true:suggestion

# name all constant fields using PascalCase
dotnet_naming_rule.constant_fields_should_be_pascal_case.severity = suggestion
dotnet_naming_rule.constant_fields_should_be_pascal_case.symbols  = constant_fields
dotnet_naming_rule.constant_fields_should_be_pascal_case.style    = pascal_case_style

dotnet_naming_symbols.constant_fields.applicable_kinds   = field
dotnet_naming_symbols.constant_fields.required_modifiers = const

dotnet_naming_style.pascal_case_style.capitalization = pascal_case

# static fields should have s_ prefix
dotnet_naming_rule.static_fields_should_have_prefix.severity = suggestion
dotnet_naming_rule.static_fields_should_have_prefix.symbols  = static_fields
dotnet_naming_rule.static_fields_should_have_prefix.style    = static_prefix_style

dotnet_naming_symbols.static_fields.applicable_kinds   = field
dotnet_naming_symbols.static_fields.required_modifiers = static

dotnet_naming_style.static_prefix_style.required_prefix = s_
dotnet_naming_style.static_prefix_style.capitalization = camel_case

# internal and private fields should be _camelCase
dotnet_naming_rule.camel_case_for_private_internal_fields.severity = suggestion
dotnet_naming_rule.camel_case_for_private_internal_fields.symbols  = private_internal_fields
dotnet_naming_rule.camel_case_for_private_internal_fields.style    = camel_case_underscore_style

dotnet_naming_symbols.private_internal_fields.applicable_kinds = field
dotnet_naming_symbols.private_internal_fields.applicable_accessibilities = private, internal

dotnet_naming_style.camel_case_underscore_style.required_prefix = _
dotnet_naming_style.camel_case_underscore_style.capitalization = camel_case

# Code style defaults
dotnet_sort_system_directives_first = true
csharp_preserve_single_line_blocks = true
csharp_preserve_single_line_statements = false

# Expression-level preferences
dotnet_style_object_initializer = true:suggestion
dotnet_style_collection_initializer = true:suggestion
dotnet_style_explicit_tuple_names = true:suggestion
dotnet_style_coalesce_expression = true:suggestion
dotnet_style_null_propagation = true:suggestion

# Expression-bodied members
csharp_style_expression_bodied_methods = false:none
csharp_style_expression_bodied_constructors = false:none
csharp_style_expression_bodied_operators = false:none
csharp_style_expression_bodied_properties = true:none
csharp_style_expression_bodied_indexers = true:none
csharp_style_expression_bodied_accessors = true:none

# Pattern matching
csharp_style_pattern_matching_over_is_with_cast_check = true:suggestion
csharp_style_pattern_matching_over_as_with_null_check = true:suggestion
csharp_style_inlined_variable_declaration = true:suggestion

# Null checking preferences
csharp_style_throw_expression = true:suggestion
csharp_style_conditional_delegate_call = true:suggestion

# Space preferences
csharp_space_after_cast = false
csharp_space_after_colon_in_inheritance_clause = true
csharp_space_after_comma = true
csharp_space_after_dot = false
csharp_space_after_keywords_in_control_flow_statements = true
csharp_space_after_semicolon_in_for_statement = true
csharp_space_around_binary_operators = before_and_after
csharp_space_around_declaration_statements = do_not_ignore
csharp_space_before_colon_in_inheritance_clause = true
csharp_space_before_comma = false
csharp_space_before_dot = false
csharp_space_before_open_square_brackets = false
csharp_space_before_semicolon_in_for_statement = false
csharp_space_between_empty_square_brackets = false
csharp_space_between_method_call_empty_parameter_list_parentheses = false
csharp_space_between_method_call_name_and_opening_parenthesis = false
csharp_space_between_method_call_parameter_list_parentheses = false
csharp_space_between_method_declaration_empty_parameter_list_parentheses = false
csharp_space_between_method_declaration_name_and_open_parenthesis = false
csharp_space_between_method_declaration_parameter_list_parentheses = false
csharp_space_between_parentheses = false
csharp_space_between_square_brackets = false

[*.{asm,inc}]
indent_size = 8

# Xml project files
[*.{csproj,vcxproj,vcxproj.filters,proj,nativeproj,locproj}]
indent_size = 2

# Xml config files
[*.{props,targets,config,nuspec}]
indent_size = 2

[CMakeLists.txt]
indent_size = 2

[*.cmd]
indent_size = 2

```

**[⬆ back to top](#table-of-contents)**

</details>

## Comments

<details>
  <summary><b>Avoid positional markers</b></summary>

They usually just add noise. Let the functions and variable names along with the proper indentation and formatting give the visual structure to your code.

**Bad:**

```csharp
////////////////////////////////////////////////////////////////////////////////
// Scope Model Instantiation
////////////////////////////////////////////////////////////////////////////////
var model = new[]
{
    menu: 'foo',
    nav: 'bar'
};

////////////////////////////////////////////////////////////////////////////////
// Action setup
////////////////////////////////////////////////////////////////////////////////
void Actions()
{
    // ...
};
```

**Bad:**

```csharp

#region Scope Model Instantiation

var model = {
    menu: 'foo',
    nav: 'bar'
};

#endregion

#region Action setup

void Actions() {
    // ...
};

#endregion
```

**Good:**

```csharp
var model = new[]
{
    menu: 'foo',
    nav: 'bar'
};

void Actions()
{
    // ...
};
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Don't leave commented out code in your codebase</b></summary>

Version control exists for a reason. Leave old code in your history.

**Bad:**

```csharp
doStuff();
// doOtherStuff();
// doSomeMoreStuff();
// doSoMuchStuff();
```

**Good:**

```csharp
doStuff();
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Don't have journal comments</b></summary>

Remember, use version control! There's no need for dead code, commented code, and especially journal comments. Use `git log` to get history!

**Bad:**

```csharp
/**
 * 2018-12-20: Removed monads, didn't understand them (RM)
 * 2017-10-01: Improved using special monads (JP)
 * 2016-02-03: Removed type-checking (LI)
 * 2015-03-14: Added combine with type-checking (JR)
 */
public int Combine(int a,int b)
{
    return a + b;
}
```

**Good:**

```csharp
public int Combine(int a,int b)
{
    return a + b;
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Only comment things that have business logic complexity</b></summary>

Comments are an apology, not a requirement. Good code _mostly_ documents itself.

**Bad:**

```csharp
public int HashIt(string data)
{
    // The hash
    var hash = 0;

    // Length of string
    var length = data.length;

    // Loop through every character in data
    for (var i = 0; i < length; i++)
    {
        // Get character code.
        const char = data.charCodeAt(i);
        // Make the hash
        hash = ((hash << 5) - hash) + char;
        // Convert to 32-bit integer
        hash &= hash;
    }
}
```

**Better but still Bad:**

```csharp
public int HashIt(string data)
{
    var hash = 0;
    var length = data.length;
    for (var i = 0; i < length; i++)
    {
        const char = data.charCodeAt(i);
        hash = ((hash << 5) - hash) + char;

        // Convert to 32-bit integer
        hash &= hash;
    }
}
```

If a comment explains WHAT the code is doing, it is probably a useless comment and can be implemented with a well named variable or function. The comment in the previous code could be replaced with a function named `ConvertTo32bitInt` so this comment is still useless.
However, it would be hard to express by code WHY the developer choose the `djb2` hash algorithm instead of `sha-1` or another hash function. In that case, a comment is acceptable.

**Good:**

```csharp
public int Hash(string data)
{
    var hash = 0;
    var length = data.length;

    for (var i = 0; i < length; i++)
    {
        var character = data[i];
        // use of djb2 hash algorithm as it has a good compromise
        // between speed and low collision with a very simple implementation
        hash = ((hash << 5) - hash) + character;

        hash = ConvertTo32BitInt(hash);
    }
    return hash;
}

private int ConvertTo32BitInt(int value)
{
    return value & value;
}
```

**[⬆ back to top](#table-of-contents)**

</details>

# Miscellaneous
**[⬆ back to top](#table-of-contents)**
## Guidelines
<div dir=rtl>
-  از Command نباید به عنوان ورودی API استفاده کنیم. باید به API ها DTO پاس دهیم. و Validation روی آن را با FluentValidation چک کنیم. (پسوند DTO های ورودی Model است)

- نباید روی Command ها Validation داشته باشیم، Validation باید روی Model  انجام بگیرد.

- خروجی API ها باید Status باشد نه Exception، مثلا در صورتی که Resource مورد نظر یافت نشود، باید 404 برگردانیم، نه 500

- خطای 500 یعنی یک مشکل از سمت سرور وجود داره (مثلا در دسترس نبودن دیتابیس) که باید برطرف بشه، خطای 400 یعنی ورودی های کلاینت مشکل داره و باید درست بشه.

- تمامی Exception ها باید از طریق Middleware به صورت Global هندل شود( نباید داخل API ها از try catch استفاده کنیم)
- در API های POST نباید 204 برگردونیم، باید 200 یا 201 برگردونیم.

- سناریو های تست باید از لحاظ بیزنسی معنی دار باشن، و هم برای Fail هم برای Success تست نوشته شود.

- توی Unit Test ها بهتره که Command handler ها رو تست کنی، چون Controller ها  توی Integration test تست میشن
- کامنت های XML برای POST و PUT باید Sample Request داشته باشن، چون همین به عنوان داکیومنت توی Swagger به کلاینت نشون داده میشه.

</div>
**[⬆ back to top](#table-of-contents)**
## Identity

Identity microservice is used to manage **users**, **passwords**, p**rofile data**, **roles**, **claims**, **tokens**, **email confirmation**, and more. Users can create an account with the login information stored in Identity or they can use an external login provider.
## Description
It's often necessary for resources and APIs published by a service to be limited to certain trusted users or clients. The first step to making these sorts of API-level trust decisions is authentication. Authentication is the process of reliably verifying a user's identity.


In this microservice we can:

-   Create new user information using the UserManager type.
-   Authenticate users using the SignInManager type. 

## Getting Started
The **Authorize** button is automatically added to Swagger.
By clicking on the **Authorize** button, you can enter the default _Username_ and _Password_, ie **bob**, and log in.




### Dependencies

* .NET 6
* SQL Server 

### Executing program

* Run the project

Get token using this curl:

```
curl --location --request POST 'https://localhost:5001/connect/token' \
--header 'Host: localhost:5001' \
--header 'Accept: application/json' \
--header 'Content-Type: application/x-www-form-urlencoded' \
--data-urlencode 'scope=api' \
--data-urlencode 'client_id=catalog' \
--data-urlencode 'client_secret=secret' \
--data-urlencode 'username=bob' \
--data-urlencode 'password=bob' \
--data-urlencode 'grant_type=password'
```

## Authors

Contributors' names and contact info

[Ali Bayat](https://www.linkedin.com/in/alibayatgh)
**[⬆ back to top](#table-of-contents)**
## Repository
Partially initialized entities are entities that are not fully constructed and returned as a result of some operation, usually an operation of fetching them from the database.

If your repository returns a list of domain entities, make sure the entities are fully initialized meaning that all their properties are filled out.

For this purpose, in implementing **Repositories in the Data project**, we override a method called `GetIncludes`. **Introduce all Navigation properties to the Repository**, so that it can load all dependent entities when retrieving data from the database.


```
public class OrderRepository : RepositoryBase<Order, long>, IOrderRepository
{
    public OrderRepository(DbContextBase context) : base(context)
    {
    }

    protected override IList<Expression<Func<Order, object>>> GetIncludes()
    {
        return new List<Expression<Func<Order, object>>>
        {
            i => i.OrderItems
        };
    }
}
```


**[⬆ back to top](#table-of-contents)**
## Project Template
[install-template.pdf](/.attachments/install-template-7dd36c49-1819-4cbe-8586-b8b611f5b329.pdf)<div dir="rtl">
<h1>  راهنمای استفاده از قالب پروژه </h1>
<br/>
1. نصب فایل Template
<div dir="ltr">Hasti.Framework.Template.1.0.0.nupkg</div>



<div dir="ltr">
cd Hasti.Framework/template
</div>
<div dir="ltr">
dotnet new --install .
</div>


2. ساخت پروژه از روی Hasti.Framework Template  یا hft 

<div dir="ltr">Dotnet new hft -n Hasti.Payment</div>

3. بررسی درست بودن آدرس پکیج های هستی فریمورک در فایل nuget.config 

4. Rename both **ServiceNameDbContext**(in _ServiceName.Persistence.EntityFramework_) and **ServiceNameQueriesDbContext**(in ServiceName.Queries.EntityFramework) by replacing the **ServiceName** part with your _YourServiceName_!

5. Update connection string both in **appsettings.json**(in ServiceName.Endpoints.WebApi) and **Scaffold.bat**(in ServiceName.Queries.EntityFramework)

6. Update-database for **ServiceNameDbContext**(in ServiceName.Persistence.EntityFramework)(remember to choose _ServiceName.Endpoints.WebApi_ as startup project beforehand)
       (you may need to use -Context switch: update-database -context ServiceNameDbContext)


<h2>  راهنمای ایجاد قالب پروژه </h2>

<div dir="ltr"> \HastiFramwork\template\Package-create.cmd</div>

<div dir="ltr"> copy nuget Template file (Hasti.Framework.Template.1.0.0.nupkg) to nuget feed </div>

<div dir="ltr"> \HastiFramwork\template\Package-Install.cmd</div>

</div>




**[⬆ back to top](#table-of-contents)**
## Google ReCAPTCHA
Package Name: Hasti.Framework.Tools.GoogleReCAPTCHA

services.**AddGoogleReCAPTCHAServices**(options =>
{
    options.**SecretKey** = "6LfAbA8gAAAAAG2Gke-D8kOZ-IKE2xWAuWOZzmY1";
    options.**ClientKey** = "6LfAbA8gAAAAAJqjwEYDyyMUxfynhw2V7N9ITKcX";
    options.**FackeReCaptchaResponse** = "google-captcha-response";
});

Set **FackeReCaptchaResponse** to disable captcha in debug mode

![image.png](/.attachments/image-8ab02577-a26c-4c6b-9e98-82313374dd2a.png)



use **GoogleReCaptchaValidationAttribute** on the captcha property form model

![image.png](/.attachments/image-3d27b0bf-8a65-49e6-8158-f9166d996bdc.png)



**[⬆ back to top](#table-of-contents)**
## Shared Context
1. add schema to Entitles
`        builder.ToTable(nameof(Tag), "ServiceName");
`
2. add schema to cap tables name, AddCapMessagingModel.
`
services.AddCapMessagingFrameworkServices(messagingOption, "catalog");
modelBuilder.AddCapMessagingModel("catalog");
`
3. change migration table name
`options.UseSqlServer( configuration.GetConnectionString("SqlServerConnectionString")
                , x => x.MigrationsHistoryTable("__EFMigrationsHistory", "ServiceName"));
`
4.other entitles service config
`        builder.ToTable(nameof(Tag), "ServiceName", c => c.ExcludeFromMigrations(true));
`

**[⬆ back to top](#table-of-contents)**
## Domain


## AggregateRoot<TKey>
##Entity<TKey>
##ValueObject

In our sample application, we have two candidates that could be represented as _value objects_ (**They have no identity and they have no identity**). They are the `Address` in the `Order` entity and the `Description` in the `Product` entity.

To implement a value object, we need to inherit from the `ValueObject` base class first.

In the sample project, in the `CatalogDbContext.cs` file, within the `OnModelCreating()` method, multiple configurations are applied. One of them is related to the Order entity.


```
protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
   // ..
   modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());

   base.OnModelCreating(modelBuilder);
  }
```


In the `Order` entity at the sample project, the `Address` value object is implemented as an **owned entity** type within the owner entity, and `Address` is a type with no identity property defined in the domain model. It is used as a property of the Order type to specify the shipping address for a particular order.


```
// Part of the OrderEntityTypeConfiguration.cs class
//
public void Configure(EntityTypeBuilder<Order> orderConfiguration)
{
    orderConfiguration.HasKey(o => o.Id);

    //Address value object persisted as owned entity
    orderConfiguration.OwnsOne(o => o.Address);

    //...Additional validations, constraints and code...
}
```



In the previous code, the `orderConfiguration.OwnsOne(o => o.Address)` method specifies that the Address property is an owned entity of the Order type.

In the `Product` entity at the sample project, the `Description` value object is implemented as a value object type within the **value conversions**.

```
public void Configure(EntityTypeBuilder<Product> builder)
{
    builder.ToTable("Product", CatalogManagementDbContext.DEFAULT_SCHEMA);

    builder.Property(x => x.Id).UseHiLo();
    
    // Description value object value conversions
    builder.Property(p => p.Description)
        .IsRequired()
        .HasMaxLength(512)
        .HasConversion(p => p.Value, p => Description.Create(p));

    builder.Ignore(b => b.DomainEvents);
}
```


To map our `Description` class to this new `Description` value object  EF Core has a feature that allows you to map single property value objects, it's called value conversions. To use this feature, we need to go to the `Product` `EntityTypeConfuguration` and indicate in the `Description` property that it has a conversion to and from plain strings.

##BusinessException   
<div dir="rtl">
همه DomianException  ها باید از BusinessException    ارث بری کنند.
کد خطا : قابلیت مشخص کردن کد خطا در BusinessException  وجود دارد.  
</div>

##DomainEvent
<div dir="rtl">
همه  DomainEventها باید از کلاس DomainEvent   ارث بری کنند.

**نکته** :  برای IntegrationEvent کردن یک  Event ،‌  از مارکر اینترفیس  IIntegrationEvent استفاده می کنیم.
</div>

##Hasti.Framework.Events 
**Hasti.Framework.Events.Abstractions**
<div dir="rtl">
تعاریف و قراردادهای مورد نیاز در موضوع Event در پروژه Abstractions قرار دارد.
پیاده سازی پیش فرض IEventBus  توسط AddDefaultFrameworkServices  به سیستم اضافه می شود.
</div>

##Hasti.Framework.Commands
**Hasti.Framework.Commands.Abstractions**
<div dir="rtl">
تعاریف و قراردادهای مورد نیاز در موضوع Command در پروژه Abstractions قرار دارد.
پیاده سازی پیش فرضICommandBus  توسط AddDefaultFrameworkServices  به سیستم اضافه می شود.
</div>

##Hasti.Framework.Events
**Hasti.Framework.Events.Abstractions**
<div dir="rtl">
تعاریف و قراردادهای مورد نیاز در موضوع Command در پروژه Abstractions قرار دارد.
پیاده سازی پیش فرض IEventBus توسط AddDefaultFrameworkServices  به سیستم اضافه می شود.
</div>
</div>


**[⬆ back to top](#table-of-contents)**
## Guidelines
<div dir=rtl>
-  از Command نباید به عنوان ورودی API استفاده کنیم. باید به API ها DTO پاس دهیم. و Validation روی آن را با FluentValidation چک کنیم. (پسوند DTO های ورودی Model است)

- نباید روی Command ها Validation داشته باشیم، Validation باید روی Model  انجام بگیرد.

- خروجی API ها باید Status باشد نه Exception، مثلا در صورتی که Resource مورد نظر یافت نشود، باید 404 برگردانیم، نه 500

- خطای 500 یعنی یک مشکل از سمت سرور وجود داره (مثلا در دسترس نبودن دیتابیس) که باید برطرف بشه، خطای 400 یعنی ورودی های کلاینت مشکل داره و باید درست بشه.

- تمامی Exception ها باید از طریق Middleware به صورت Global هندل شود( نباید داخل API ها از try catch استفاده کنیم)
- در API های POST نباید 204 برگردونیم، باید 200 یا 201 برگردونیم.

- سناریو های تست باید از لحاظ بیزنسی معنی دار باشن، و هم برای Fail هم برای Success تست نوشته شود.

- توی Unit Test ها بهتره که Command handler ها رو تست کنی، چون Controller ها  توی Integration test تست میشن
- کامنت های XML برای POST و PUT باید Sample Request داشته باشن، چون همین به عنوان داکیومنت توی Swagger به کلاینت نشون داده میشه.

</div>
**[⬆ back to top](#table-of-contents)**
## Learning
**CQRS.in.Practice** (#vladimir-khorikov-pluralsight)
\\172.27.226.6\Developer\Learning Courses\CQRS.in.Practice

**Domain.Driven.Design.in.Practice** (Vladimir Khorikov-Pluralsight)
\\172.27.226.6\Developer\Learning Courses\Domain.Driven.Design.in.Practice

**[⬆ back to top](#table-of-contents)**

#Release Notes(#release-notes)

## Hasti framework version 1.0.7 Releases
July 4, 2022 — - [Hasti framework version 1.0.7-Beta35](#Hasti-framework-version-1.0.7-Beta35) 



### Issues Addressed in this release of 1.0.7-Beta35
- Call the SaveChangesAsync from CommandBus

### Issues Addressed in this release of 1.0.7-Beta36
- Add the Async postfix to RepositoryBase class



**[⬆ back to top](#table-of-contents)**
