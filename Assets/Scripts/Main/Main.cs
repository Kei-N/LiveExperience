using Cysharp.Threading.Tasks;
using LiveExperience.Audio;
using LiveExperience.Data;
using LiveExperience.Environment;
using LiveExperience.Input;
using LiveExperience.UI;
using LiveExperience.XR;
using System;
using System.Threading;
using UnityEngine;

namespace LiveExperience
{
    /// <summary>
    /// プログラムのエントリーポイントを定義します。
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class Main : MonoBehaviour
    {
        [SerializeField] private Player.PlayerController m_PlayerController = null;
        [SerializeField] private AudioManager m_AudioManager = null;
        [SerializeField] private DataManager m_DataManager = null;
        [SerializeField] private InputManager m_InputManager = null;
        [SerializeField] private UIManager m_UIManager = null;
        [SerializeField] private XRManager m_XRManager = null;
        [SerializeField] private EnvironmentController m_EnvironmentController = null;

        /// <summary>
        /// エントリーポイントです。
        /// </summary>
        private async UniTask Start()
        {
            try
            {
                await InitializeAsync();

                //while (true)
                {
                    //await ResetAsync();

                    //await ProcessAsync();

                    UpdateLoop(this.GetCancellationTokenOnDestroy()).Forget();
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }

        /// <summary>
        /// 初期化処理を実行します。
        /// </summary>
        private async UniTask InitializeAsync()
        {
            m_PlayerController.Initialize();
            m_AudioManager.Initialize();
            m_DataManager.Initialize();
            m_InputManager.Initialize();
            m_UIManager.Initialize();
            m_XRManager.Initialize();

            await UniTask.Yield();
        }

        /// <summary>
        /// Update処理を実行します。
        /// </summary>
        private async UniTaskVoid UpdateLoop(CancellationToken cancellationToken)
        {
            while (true)
            {
                // Updateで実行する処理をここに記述する
                Debug.Log("hoge");

                await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
            }
        }
    }
}