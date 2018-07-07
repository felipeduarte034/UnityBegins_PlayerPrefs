using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    private const string KEY_PONTOS = "key_pontos";

    [Header("Settings")]
    [SerializeField] float m_Speed = 10f;

    [Header("Links")]
    [SerializeField] Text m_TextPontos;

    [Header("Observar")]
    [SerializeField] int pontos = 0;
    [SerializeField] float v;
    [SerializeField] float h;

    void Awake()
    {
        pontos = PlayerPrefs.GetInt(KEY_PONTOS, 0);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        if (m_TextPontos) { m_TextPontos.text = pontos.ToString(); }

        MovimentarPlayer(h, 0f, v, m_Speed);
    }

    private void MovimentarPlayer(float x, float y, float z, float speed)
    {
        transform.Translate(new Vector3(x * speed * Time.deltaTime, y, z * speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject, .5f);
            pontos += 10;
            PlayerPrefs.SetInt(KEY_PONTOS, pontos);
        }
    }
}
