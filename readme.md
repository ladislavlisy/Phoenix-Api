# PHOENIX-API

## Design API
Home
-> Customer
-> CreateCustomer(firstName, lastName, email, phone, text)
-> CreatedCustomer
-> Home
Home
-> Account
-> CreateAccount(customerId, defaultDiscount, creditLimit)
-> CreatedAccount
-> Home
Home
-> SalesActivity
-> CreateActivity(customerId, accountId, salesRepId, callDate)
-> CreatedActivity
-> Home

Home
->Customer
->CreateCustomer(givenName, FamilyName, emailAddress, phoneNumber, smsNumber)
->CreatedCustomer
->Account
->CreateAccount(customerId, defaultDiscount, creditLimit)
->CreatedAccount
->SalesActivity
->CreateActivity(customerId, accountId, salesRepId, callDate)
->CreatedActivity
->Home

## Onboarding API Workflow
Home -> WIP
WIP -> CancelWIP -> Home
WIP -> CustomerData(firstName, lastName, email, phone, text) -> WIP
WIP -> AccountData(customerId, defaultDiscount, creditLimit) -> WIP
WIP -> ActivityData(customerId, accountId, salesRepId, callDate) -> WIP
WIP -> FinalizeWIP -> Home

## Validated Names
* givenName := https://schema.org/givenName
* familyName := https://schema.org/familyName
* email := https://schema.org/email
* telephone := https://schema.org/telephone
* text := https://schema.org/Text
* date := https://schema.org/Date
* discount := https://schema.org/discount
* customerId := http://glossary.bigco.com/customerId
* creditLimit := http://glossary.bigco.com/creditLimit
* accountId := http://glossary.bigco.com/accountId
* salesRepId := http://glossary.bigco.com/salesRepId
* Home := http://glossary.bigco.com/Home
* CreateCustomer := http://glossary.bigco.com/CreateCustomer
* CreatedCustomer := http://glossary.bigco.com/CreatedCustomer
* Account := http://glossary.bigco.com/Account
* CreateAccount := http://glossary.bigco.com/CreateAccount
* CreatedAccount := http://glossary.bigco.com/CreatedAccount
* SalesActivity := http://glossary.bigco.com/SalesActivty
* CreatedActivity := http://glossary.bigco.com/CreatedActivity

## Diagram
https://www.websequencediagrams.com/

## Resources
• Home
• Customer
• CreatedCustomer
• Account
• CreatedAccount
• Activity
• CreatedActivity

## Transitioms
• startOnboarding
• completeOnboarding
• abandonOnboarding
• collectCustomerData
• collectAccountData
• collectActivityData
• SaveToWIP
• goHome

## Identiers
• identifier
• givenName
• familyName
• email
• telephone
• text

## designing/diagram-onboarding-02.wsd
Home->+WIP:
WIP->+cancelWIP:
cancelWIP-->-Home:
WIP->+customerData:
customerData-->-WIP:
WIP->+accountData:
accountData-->-WIP:
WIP->+activityData:
activityData-->-WIP:
WIP->+finalizeWIP:
finalizeWIP-->Home:

## designing/diagram-onboarding-03.wsd
home->+WIP: startOnboarding
WIP->+customerData: collectCustomerData
customerData-->-WIP: saveToWIP
WIP->+accountData: collectAccountData
accountData-->-WIP:saveToWIP
WIP->+activityData: collectActivityData
activityData-->-WIP:saveToWIP
WIP-->+finalizeWIP:completeOnboarding
finalizeWIP->-home:goHome
WIP->+cancelWIP:abandonOnboarding
cancelWIP-->-home:goHome

## designing/diagram-onboarding-04.wsd
home->+WIP: startOnboarding(identifier)
WIP->+customerData: collectCustomerData(identifier, givenName, familyName, email, telephone, text)
customerData-->-WIP: saveToWIP(identifier, givenName, familyName, email, telephone, text)
WIP->+accountData: collectAccountData(identifier, discount, creditLimit)
accountData-->-WIP:saveToWIP(identifier,discount, creditLimit)
WIP->+activityData: collectAccountData(identifier, salesRepId, callDate)
activityData-->-WIP:saveToWIP(identifier, salesRepId, callDate)
WIP-->+finalizeWIP:completeOnboarding(identifier)
finalizeWIP->-home:goHome
WIP-->+cancelWIP:abandonOnboarding(identifier)
cancelWIP->-home:goHome

home -> listOnboardings:
listOnboardings --> home:
listOnboardings -> createOnboardingF:
createOnboardingF --> listOnboardings:
listOnboardings -> readOnboarding:
readOnboarding --> listOnboardings:
readOnboarding -> addCompanyInfoF:
addCompanyInfoF --> readOnboarding:
readOnboarding -> addAccountInfoF:
addAccountInfoF --> readOnboarding:
readOnboarding -> addActivityInfoF:
addActivityInfoF --> readOnboarding:
readOnboarding -> approveOnboardingF:
approveOnboardingF --> readOnboarding:
readOnboarding -> rejectOnboardingF:
rejectOnboardingF --> readOnboarding:


## describing/onboarding-alps-01.js
{
    "alps" : {
        "title" : "Onboarding API",
        "doc" : {
            "type" : "markdown",
            "value" : "This is the ALPS document for BigCo's **Onboarding API**."
         }
    }
}

## describing/onboarding-alps-02.js
{
    "alps" : {
        "title" : "Onboarding API",
        "doc" : {
            "type" : "markdown",
            "value" : "This is the ALPS document for BigCo's **Onboarding API**."
        },
        "descriptor" : [
            {
                "id" : "identifier",
                "type" : "semantic",
                "text" : "Unique identifier for this record",
                "rel" : "http://schema.org/identifier"
            },
            {
                "id" : "givenName",
                "type" : "semantic",
                "text" : "Customer's first name",
                "rel" : "http://schema.org/givenName"
            },
            {
                "id" : "familyName",
                "type" : "semantic",
                "text" : "Customer's last name",
                "rel" : "http://schema.org/familyName"
            },
            {
                "id" : "email",
                "type" : "semantic",
                "text" : "Customer's primary email account",
                "rel" : "http://schema.org/email"
            },
            {
                "id" : "telephone",
                "type" : "semantic",
                "text" : "Customer's phone number",
                "rel" : "http://schema.org/telephone"
            },
            {
                "id" : "status",
                "type" : "semantic",
                "text" : "Account status (active, inactive, suspended)",
                "rel" : "http://schema.org/status"
            },
            {
                "id" : "maxValue",
                "type" : "semantic",
                "text" : "Account's maximum spending limit",
                "rel" : "http://schema.org/maxValue"
            },
            {
                "id" : "discount",
                "type" : "semantic",
                "text' : "Account's default sales discount (as a percentage)",
                "rel" : "http://schema.org/discount"
            }
        ]
    }
}

exports.props = [
'id','status','dateCreated','dateUpdated',
'companyId','companyName','streetAddress','city','stateProvince',
'postalCode','country','telephone','email',
'accountId','division','spendingLimit','discountPercentage',
'activityId','activityType','dateScheduled','notes'
];

// enumerated properties
exports.enums = [
{status:
['pending','active','suspended','closed']
},
{division:
['DryGoods','Hardware','Software','Grocery','Pharmacy','Military']
},
{activityType:
['email','inperson','phone','letter']
}
];

exports.defs = [
{name:"spendingLimit", value:"10000"},
{name:"discountPercentage", value:"10"},
{name:"activityType", value:"email"},
{name:"status",value:"pending"}
];
