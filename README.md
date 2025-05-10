# LT_CSharp_Asserts

Asserts are used in tests to confirm an expected result.

## Configure Environment Variables

Before the tests are run, please set the environment variables LT_USERNAME & LT_ACCESS_KEY from the terminal. The account details are available on your [LambdaTest Profile](https://accounts.lambdatest.com/detail/profile) page.

For macOS:

```bash
export LT_USERNAME=LT_USERNAME
export LT_ACCESS_KEY=LT_ACCESS_KEY
```

For Linux:

```bash
export LT_USERNAME=LT_USERNAME
export LT_ACCESS_KEY=LT_ACCESS_KEY
```

For Windows:

```bash
set LT_USERNAME=LT_USERNAME
set LT_ACCESS_KEY=LT_ACCESS_KEY
```

Please visit [LambdaTest Capabilities Generator](https://www.lambdatest.com/capabilities-generator/) to generate capabilities for the test cases.

## How to run tests

Once the environment variables are exported, run the following command from the terminal (after navigating to the root directory):

```bash
dotnet test LT_CSharp_Asserts.sln 
```
