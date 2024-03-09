﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SeleniumGameShopQA.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Tworzenie nowego konta przez administratora")]
    public partial class TworzenieNowegoKontaPrzezAdministratoraFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "AdminCreateUser.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pl"), "Features", "Tworzenie nowego konta przez administratora", "  Jako administrator systemu\r\n  Chcę móc tworzyć nowe firmy\r\n  Aby móc zarządzać " +
                    "nimi w systemie", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
  #line hidden
#line 8
    testRunner.Given("otwieram stronę logowania do panelu administracyjnego", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Zakładając, że ");
#line hidden
#line 9
    testRunner.When("wybieram opcję Zaloguj", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Kiedy ");
#line hidden
#line 10
    testRunner.And("wpisuję email administratora", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 11
    testRunner.And("wpisuję hasło administratora", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 12
    testRunner.And("zatwierdzam formularz logowania", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 13
    testRunner.Then("jestem zalogowany do systemu jako administrator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wtedy ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pomyślne dodanie nowego konta przez administratora")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        public void PomyslneDodanieNowegoKontaPrzezAdministratora()
        {
            string[] tagsOfScenario = new string[] {
                    "smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pomyślne dodanie nowego konta przez administratora", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 16
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
  this.FeatureBackground();
#line hidden
#line 17
    testRunner.Given("jestem zalogowany jako administrator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Zakładając, że ");
#line hidden
#line 18
    testRunner.When("wybieram zakładkę Utwórz użytkownika", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Kiedy ");
#line hidden
#line 19
    testRunner.And("wypełniam formularz danymi nowego konta", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 20
    testRunner.And("wybieram opcję Rejestruj", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 21
    testRunner.Then("nowe konto zostaje dodane do bazy danych", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wtedy ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pomyślne logowanie na nowo utworzone konto przez administratora")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        public void PomyslneLogowanieNaNowoUtworzoneKontoPrzezAdministratora()
        {
            string[] tagsOfScenario = new string[] {
                    "smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pomyślne logowanie na nowo utworzone konto przez administratora", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 26
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
  this.FeatureBackground();
#line hidden
#line 27
    testRunner.Given("otwieram stronę logowania do panelu administracyjnego", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Zakładając, że ");
#line hidden
#line 29
    testRunner.When("wybieram opcję Zaloguj", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Kiedy ");
#line hidden
#line 30
    testRunner.And("wpisuję email utworzonego konta", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 31
    testRunner.And("wpisuję hasło utworzonego konta", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 32
    testRunner.And("zatwierdzam formularz logowania", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 33
    testRunner.Then("jestem zalogowany do systemu jako nowy użytkownik", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wtedy ");
#line hidden
#line 34
    testRunner.And("usuwam konto z bazy danych", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
