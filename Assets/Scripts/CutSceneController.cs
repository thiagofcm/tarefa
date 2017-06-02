using System.Collections.Generic;
using UnityEngine;

public class CutSceneController : MonoBehaviour
{

    public static CutSceneController instancia = null;

    public AudioClip musica;

    public List<Camera> cameras = new List<Camera>();
    List<Animator> anim = new List<Animator>();

    int ativa;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != null)
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < cameras.Count; i++)
        {
            anim.Add(cameras[i].GetComponent<Animator>());
            desativarCamera(i);
        }
        ativa = 0;
        ativarCamera(ativa);
        audioSource.PlayOneShot(musica);
    }

    void ativarCamera(int i)
    {
        cameras[i].depth = 1;
        anim[i].SetTrigger("start");
    }
    void desativarCamera(int i)
    {
        cameras[i].depth = 0;
    }

    public void ProximaCamera()
    {
        if (ativa < cameras.Count - 1)
        {
            ativa++;
            ativarCamera(ativa);
            desativarCamera(ativa - 1);
        }
        else
        {
            desativarCamera(ativa);
            audioSource.Stop();
            GameController.instancia.TriFinishCutScene();
            Destroy(this.gameObject);
        }
    }
}
