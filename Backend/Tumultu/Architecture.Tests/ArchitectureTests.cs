using MediatR;
using NetArchTest.Rules;
using System.Reflection;

namespace Architecture.Tests;

public class ArchitectureTests
{
    private const string Domain = "Tumultu.Domain";
    private const string Application = "Tumultu.Application";
    private const string Infrastructure = "Tumultu.Infrastructure";
    private const string Presentation = "Tumultu.Presentation";

    private readonly Dictionary<string, Assembly> _assemblies = new Dictionary<string, Assembly>()
    {
        { Domain, typeof(Tumultu.Domain.AssemblyReference).Assembly },
        { Application, typeof(Tumultu.Application.AssemblyReference).Assembly },
        { Infrastructure, typeof(Tumultu.Infrastructure.AssemblyReference).Assembly },
        { Presentation, typeof(Tumultu.Presentation.AssemblyReference).Assembly }
    };

    [Fact]
    public void Domain_Should_NotHaveDependencyOnOtherProjects()
    {
        // Arrange
        var domainAssembly = _assemblies[Domain];

        // Act
        TestResult result = Types
            .InAssembly(domainAssembly)
            .Should()
            .NotHaveDependencyOnAll(Application, Infrastructure, Presentation)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_HaveDependenciesOnlyOnDomainLayer()
    {
        // Arrange
        var applicationAssembly = _assemblies[Application];

        // Act
        TestResult result = Types
            .InAssembly(applicationAssembly)
            .Should()
            .NotHaveDependencyOnAll(Infrastructure, Presentation)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infrastructure_Should_HaveDependenciesOnlyOnDomainAndInfrastructureLayer()
    {
        // Arrange 
        var infrastructureAssembly = _assemblies[Infrastructure];

        // Act
        TestResult result = Types
            .InAssembly(infrastructureAssembly)
            .Should()
            .NotHaveDependencyOnAll(Presentation)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Handlers_Should_HaveDependencyOnDomain()
    {
        // Arrange
        var assembly = _assemblies[Application];

        // Act
        TestResult result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Handler")
            .Should()
            .HaveDependencyOn(Domain)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainEvents_Should_HaveEventSuffix()
    {
        // Arrange
        var assembly = _assemblies[Domain];

        // Act
        TestResult result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(INotification))
            .Should()
            .HaveNameEndingWith("Event")
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainEvents_Should_BeSealed()
    {
        // Arrange
        var assembly = _assemblies[Domain];

        // Act
        var result = Types
            .InAssembly(assembly)
            .That()
            .ResideInNamespace("Tumutlu.Domain.Events")
            .Should()
            .BeSealed()
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Queries_Should_ImplementFromIRequest()
    {
        // Arrange
        var assembly = _assemblies[Application];

        // Act
        TestResult result = Types
            .InAssembly(assembly)
            .That()
            .AreNotClasses()
            .And()
            .HaveNameEndingWith("Query")
            .Should()
            .ImplementInterface(typeof(IRequest))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void QueryHandlers_Should_ImplementFromIRequestHandler()
    {
        // Arrange
        var assembly = _assemblies[Application];

        // Act
        TestResult result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("QueryHandler")
            .Should()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }


    [Fact]
    public void Commands_Should_ImplementFromIRequest()
    {
        // Arrange
        var assembly = _assemblies[Application];

        // Act
        TestResult result = Types
            .InAssembly(assembly)
            .That()
            .AreNotClasses()
            .And()
            .HaveNameEndingWith("Command")
            .Should()
            .ImplementInterface(typeof(IRequest))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }


    [Fact]
    public void CommandHandlers_Should_ImplementFromIRequestHandler()
    {
        // Arrange
        var assembly = _assemblies[Application];

        // Act
        TestResult result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("CommandHandlers")
            .Should()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }


    [Fact]
    public void EventHandlers_Should_ImplementINotificationHandler()
    {
        // Arrange
        var assembly = _assemblies[Application];

        // Act
        TestResult result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("EventHandler")
            .Should()
            .ImplementInterface(typeof(INotificationHandler<>))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}