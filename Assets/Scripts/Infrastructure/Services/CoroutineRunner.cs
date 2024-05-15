// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// namespace BlockBreaker.Infrastructure.Services
// {
//     public class CoroutineRunner : MonoBehaviour
//     {
//         private readonly Dictionary<Action, List<Coroutine>> _coroutines = new();
//         
//         IEnumerator InvokeRoutine(Action action, YieldInstruction instruction)
//         {
//             yield return instruction;
//             action.Invoke();
//             _coroutines[action] = default;
//         }
//         
//         public void StartInvokeCoroutine(Action action, YieldInstruction instruction = default)
//         {
//             if (action != default)
//             {
//                 _coroutines.TryAdd(action, new List<Coroutine>()); 
//                 _coroutines[action].Add(StartCoroutine(InvokeRoutine(action, instruction)));
//             }
//         }
//         public void StartInvokeCoroutine(Action action, float secondsToInvoke) =>
//             StartInvokeCoroutine(action, new WaitForSeconds(secondsToInvoke));
//         public void StopInvokeCoroutine(Action action)
//         {
//             if (_coroutines.ContainsKey(action))
//             {
//                 StopCoroutine(_coroutines[action]);
//                 _coroutines[action] = default;
//             }
//         }
//         public bool IsCoroutineRunning(Action action) => _coroutines.ContainsKey(action);
//     }
// }