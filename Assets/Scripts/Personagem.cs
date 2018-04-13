using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour {
	Animator animator;
	float axis;
	Vector2 velocidade;
	private Rigidbody2D rb;

	// Para os botões touch
	public GameObject botaoDireita;
	public GameObject botaoEsquerda;
	public GameObject botaoPular;
	public GameObject botaoAtaque;
	public GameObject botaoPause;
	Button componentDir;
	Button componentEsq;
	Button componentPular;
	Button componentAtaque;
	Button componentPause;


	public static bool ataque = false;
	public static bool dano = false;


	/* Indica para que lado o personagem está olhando.
	 * Como o sprite do personagem criado é olhando para o lado direito, 
	 * então o valor da variável é verdadeiro (true);
	 */
	public static bool ladoDireito = true;
	bool noChao = false; //Verifica se o personagem está em contato com o chão;
	bool naParede = false; //Verifica se o personagem está em contato com a parede;

	// Adicionamos uma força no eixo Y para o pulo
	public float forcaY = 120;

	// É o tamanho da esfera imaginária que será gerada ao redor do ChaoCheck.
	// Essa esfera será tipo um Colisor mas diferente;
	float chaoCheckRaio = 0.2f;
	float paredeCheckRaio = 0.45f;


	// É pública, o que permite que possamos alterar o seu valor no painel Inspector no Unity
	public float MaxVelocidade = 8;

	public Transform ChaoCheck; //É a posição do ChaoCheck que criamos
	public Transform ParedeCheck; 

	// São todas as Layers que consideramos chão. Também será atribuída através do editor.
	public LayerMask OQueEChao;



	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft; //bloqueia a rotação do celular deixando o jogo sempre na horizontal.
		//yield return new WaitForSeconds (5);
		// botões touch
		componentDir = botaoDireita.GetComponent<Button> ();
		componentEsq = botaoEsquerda.GetComponent<Button> ();
		componentPular = botaoPular.GetComponent<Button> ();
		componentAtaque = botaoAtaque.GetComponent<Button> ();
		componentPause = botaoPause.GetComponent<Button> ();

		animator = GetComponent<Animator> ();

	}

	public void update(){
		
	}

	public void FixedUpdate()
	{
		if (VidaPersonagem.vidaAtual <= 0) {
			SceneManager.LoadScene ("gameOver");
		}

		//print (ladoDireito);

		/* Physics2d.OverlapCircle é a que cria o círculo imaginário ao redor do ChaoCheck 
		 * com tamanho de chaoCheckRaio e só retorna verdadeiro quando este círculo está 
		 * em contato com as Layers OQueEChao.
		 */
		naParede = Physics2D.OverlapCircle (ParedeCheck.position, paredeCheckRaio, OQueEChao);
		noChao = Physics2D.OverlapCircle (ChaoCheck.position, chaoCheckRaio, OQueEChao);
		animator.SetBool ("NoChao", noChao);

		// Serve para saber quando o jogador pressionou um dos botões considerados como movimento horizontal.
		// Quando pressionado, input retorna maior que 0.
		axis = Input.GetAxis ("Horizontal");
		if (axis > 0 && !ladoDireito)
			Vire ();
		if (axis < 0 && ladoDireito)
			Vire ();
		
		if (!naParede) {
			velocidade = new Vector2 (axis * MaxVelocidade, GetComponent<Rigidbody2D> ().velocity.y);
			animator.SetFloat ("Velocidade", Mathf.Abs (axis));
			GetComponent<Rigidbody2D> ().velocity = velocidade;
			animator.SetFloat ("VelocidadeVertical", GetComponent<Rigidbody2D> ().velocity.y);
		}


		// Para botões touch

		if (componentAtaque.input == 1 || Input.GetKeyDown ("f")) {
			ataque = true;
		}

		if (componentEsq.input == 1) {
			if (ladoDireito == true) {
				Vire ();
			} else {
				ladoDireito = false;
			}
			if (!naParede) {
				transform.Translate (-MaxVelocidade * Time.deltaTime, 0, 0);
				animator.SetFloat ("Velocidade", 3);
			}
		}
		if (componentDir.input == 1) {
			if (ladoDireito == false) {
				Vire ();
			} else {
				ladoDireito = true;
			}
			if (!naParede) {
				transform.Translate (MaxVelocidade * Time.deltaTime, 0, 0);
				animator.SetFloat ("Velocidade", 3);
			}
		}
		if (componentPular.input == 1 && noChao) {
			animator.SetBool ("NoChao", false);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, forcaY * 2));

		}
		if (naParede) {
			animator.SetFloat ("Velocidade", 0);
		}
	

		/* Verificamos se o personagem está no chão e se o botão de pulo foi pressionado.
	 * Se sim, adicionamos uma força no eixo Y com a variavel forcaY,
	 * a qual fará o personagem ser “jogado” para cima.
	 */
		if (noChao && Input.GetButton ("Jump")) {
			animator.SetBool ("NoChao", false);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, forcaY));
		}

	}
	

	// Faz a imagem olhar para o lado oposto;
	void Vire(){
		ladoDireito = !ladoDireito;
		Vector2 novoScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
		transform.localScale = novoScale;
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;

		Gizmos.DrawWireSphere (ParedeCheck.position, paredeCheckRaio);
		Gizmos.DrawWireSphere (ChaoCheck.position, chaoCheckRaio);
	}


	void OnCollisionEnter2D(Collision2D colisao)
	{
		if (colisao.gameObject.tag == "morre") 
		{
			SceneManager.LoadScene ("gameOver");

		}else if (colisao.gameObject.tag == "sair") 
		{
			Application.Quit();

		}else if (colisao.gameObject.tag == "dano") 
		{
			dano = true;
		}
	}


}	
