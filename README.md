# Email Notification System

## Overview

Thank you for the opportunity to work on this assigment. Below, I will outline the approach I took to complete the tasks as per the requirements. 
The Email Notification System is a .NET 6.0 application designed to manage and send email notifications to clients based on various campaigns and templates. 
The system is built using the Onion Architecture, promoting separation of concerns and testability.


### Key Features

- **Client Management**: Manage clients and their associated email configurations.
- **Campaign Management**: Create and manage email campaigns, linking them to specific templates.
- **Template Management**: Define and manage reusable email templates.
- **Email Sending**: Send individual and bulk emails to clients based on specified campaigns.

## Solution Structure

The solution consists of the following projects:

### 1. **ZoranMedia.Domain**
Contains the core domain entities and their relationships.

#### Entities
- **Client**: Represents an individual client.
- **Configuration**: Stores settings for clients.
- **Template**: Defines the structure and content of email messages.
- **Campaign**: Represents a batch of emails to be sent.
- **Email**: Represents individual email records.

#### Interfaces
- **IEmailService**: Interface for email sending services.
- **ICampaignService**: Interface for managing campaigns.
- **IConfigurationService**: Interface for managing configurations.

### 2. **ZoranMedia.Application**
Contains application logic, including services and DTOs.

#### Services
- **EmailService**: Implements email sending logic.
- **CampaignService**: Implements campaign management logic.
- **ConfigurationService**: Implements configuration management logic.

#### DTOs
- **CampaignClientTemplateDTO**: Data transfer object for campaigns and templates.

### 3. **ZoranMedia.Infrastructure**
Contains data access logic, including Entity Framework configurations and repositories.

#### Repositories
- **ClientRepository**: Repository for client data access.
- **CampaignRepository**: Repository for campaign data access.
- **TemplateRepository**: Repository for template data access.

### 4. **ZoranMedia.Web**
The web application project that handles user interactions.

#### Features
- **Razor Pages**: User interfaces for managing clients, campaigns, and templates. Some of the views are not implemented due to lack of time.
- **Microsoft Identity**: partially implemented. 
- **Email Sending**: Interfaces to trigger email sending based on client data.
- **Databse Connection String** is placed in the appsettings.json
- **Azure Connection String** is placed in the appsettings.json
- **XML parsing feature is in progress
- **Parallel procesing feature i planed to implement with Worker services or with Azure Logic Apps

### 5. **ServiceBusMessageProcessor**
Azure Function to handle email sending and background processing. I have tried to implement with SendGrid and with MailKit but does not succeed due to technical issues on their side.

### Prerequisites

- .NET 6.0 SDK
- SQL Server or another database of your choice
- Azure Subscription (for Azure Functions)