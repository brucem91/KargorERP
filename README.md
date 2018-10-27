# KargorERP

## Project Overview

## Quick Start for Development

### Pre-requisites

The following software is required in order to develop KargorERP.

1. [.NET Core 2.1](https://www.microsoft.com/net/download)
2. [Node.js 8.12.0+](https://nodejs.org)
3. [Git](https://git-scm.com)

You will also need access to a database in order to save your data.

### Setup Guide

Fetch this project from [github](https://github.com/brucem91/KargorERP)

```bash
$ git clone https://github.com/brucem91/KargorERP.git
```

Move into application directory

```bash
$ cd KargorERP
```

Install all dependencies

```bash
$ npm run install
```

Create an environment file with your local settings. You will want to edit this file
with settings appropriate to your development environment.

```bash
$ cp .env.example .env
```

(Optional) Open the application with your IDE of choice (Visual Studio Code for example)

```bash
$ code .
```

Run the application in development mode. Note that any code changes will automatically
restart both the frontend and the backend.

```bash
$  npm run start
```