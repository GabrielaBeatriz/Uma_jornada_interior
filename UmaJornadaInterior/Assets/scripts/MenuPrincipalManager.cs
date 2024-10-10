using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
   [SerializeField] private string NomeDoLevelDeJogo;
   [SerializeField] private GameObject PainelMenuInicial;
   [SerializeField] private GameObject PainelOpcoes;
   
   public void Play()
   {
      SceneManager.LoadScene("JornadaInterior");
   }

   public void AbrirOptions()
   {
      PainelMenuInicial.SetActive(false);
      PainelOpcoes.SetActive(true);
   }

   public void FecharOptions()
   {
      PainelOpcoes.SetActive(false);
      PainelMenuInicial.SetActive(true);

   }

   public void BackGame()
   {
      Debug.Log("sair do jogo");
      Application.Quit();
   }
}
