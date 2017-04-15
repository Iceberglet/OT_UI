OT with UI.
=============================

**IMPORTANT NOTE: This Project Needs Dependency on GaussianRegression Project: https://github.com/Iceberglet/GaussianRegression/tree/ForOT
For Ordinal Transformation Research Usage, Take the "ForOT" branch. Set up dependencies in your project that needs to reference this library. (Usually by pointing at the executable from the test build is sufficient)**

**Use the (MultiFidelity) Branch For Latest Updates**

Usage
-----

1. Using the UI.

   The UI consists only "initialize" and "start(play)" buttons. I have removed all other unused functionalities.

   Initialize will, as the name suggests, initialize the sampling algorithm. This is done in `Controller.initialize()`  

   Iterate your algorithm. This is done in `Controller.iterate()`  
   
   (The initialize takes around twenty seconds for this latest commit. Please be patient)

2. Not using the UI.

   You can opt not to use the UI in order to do some other stuff with the algorithms, say, evaluate performance after 100 tests, each with 50 iterations, etc.  
   To do that, in `Program.Main()`, comment off the three lines:
```csharp
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);
Application.Run(new Form1());
```
Then include whatever code you wish for.
Alternatively, you can include more UI to accomplish desired functionalities (Do research on how C# does this :)

3. Algorithms.

   The MO2TOS algorithm can be found in Algorithms folder. All algorithms inherit `Algorithm` class with the following functions:  
   `initialize(List<Solution> solutions)` to do whatever initialization necessary (e.g. for MO2TOS, divide them into k groups)  
   `iterate()` to advance one iteration. In order to sample one design, use `sample(Solution s)`.  
   **NOTE: Nothing prevents you from sampling more than once, or tamper with the solutions and the sampled set. Be careful that you do not make such mistakes
during the sampling process**

4. Single and Multiple Low Fidelity.

   Note there is also a `AlgorithmMultiF`. This is for algorithms that work on multiple low fidelity functions. Every element in the Algorithm folder has a counterpart.  
   for this. For example, `SolutionMultiF` includes more Low Fidelity Values than `Solution`.  
   The mechanisms are essentially the same as that for single low fidelity.

5. `ControllerSingle` and `ControllerMulti` are merely two copies of `Controller` which I used to convert between the two modes more easily. Their contents are good points to start in order to understand the whole process.
