using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class StackNode  
    {
        public String x;
        public StackNode devam;
        public StackNode(string x, StackNode ust)
        {
            this.x = x;
            this.devam = ust;
        }
    }


    class Program
    {
    public static bool Gecerlilik { get; private set; }

    public StackNode ust;
    static bool operatorkontrol(char x) // operator kontrol metodu
        {
            if (x == '+' || x=='-' || x=='*' || x == '/')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool operandkontrol(char x) // operand kontrol metodu
        {
            if((x>='a' && x<='z') || x>='A' && x<='Z')
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public int sayac;
        public int boyut() // yiginin boyutu
        {
            return this.sayac;
        }
        public bool bos() // yığının boş olması durumu
        {
            if (this.boyut() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Push(String x) // push metodu altta belirttiğim hatayı düzeltmek için kendim eklemem gerekti
        {
            this.ust = new StackNode(x, this.ust);
            this.sayac++;
        }
        public String Pop()  // pop metodu altta belirttiğim hatayı düzeltmek için kendim eklemem gerekti
    {
            string gecici = "";
            if (this.bos() == false)
            {
                gecici = this.ust.x;
                this.ust = this.ust.devam;
                this.sayac--;
            }
        return gecici;
        }
 
        public void ictaki(string ontaki)  // prefix girdiyi infix çevirdiğim metod
        {
            var yigin=new Program();
            var uzunluk = ontaki.Length;
            bool Gecerlilik = true;
            string op1 = "";
            string op2 = "";
            string gecici = "";
            for (int i=uzunluk-1; i>=0; i--)
            {
                char okunankarakter = ontaki[i];
                if (operatorkontrol(okunankarakter)) // operator kontrolü yapılıyor eğer operator okunup yığın boş değil ise yığından çekiliyor değil ise bool olarak tanımladığım Gecerlilik değişkeni false oluyor
                {
                    
                    if (yigin.boyut() > 1)
                    {
                        op1 = yigin.Pop().ToString();
                        if (yigin.ToString() != "") // hatayı düzeltmeye çalışırken yazmıştım ancak şu anda kodu engellemediği için bu şekilde bırakmak istedim her hangi bir etkisi yok şu an
                        {
                            op2 = yigin.Pop().ToString(); // ilk aldığım hata yeri -- yığının boş olduğu uyarısını veriyordu o açıdan StackNode - Pop - Push - boyut metotlarını elle eklemem gerekti
                            gecici = "(" + op1 + okunankarakter + op2 + ")";
                            yigin.Push(gecici);
                        }
                        else
                        {
                            Gecerlilik = false;  
                        }
                    }
                    else
                    {
                        Gecerlilik = false;
                    }
                }
                else if(operandkontrol(okunankarakter))  // okunan karakterin operand olması durumunda yığına itiliyor
                {
                    gecici = okunankarakter.ToString();
                    yigin.Push(gecici);
                    
                }
                else
                {
                    Gecerlilik = false;
                }
            }
        if (Gecerlilik == false)
        {
            Console.WriteLine("Hatalı öntakı ifade");
        }
        else
        {
            Console.Write("İctaki biçimi: " + yigin.Pop());
        }

        
        }

        static void Main(String[] args)
        {
            var task = new Program();
            string ontaki;
            Console.Write("Öntakı ifade girin: ");
            ontaki = Console.ReadLine();
            task.ictaki(ontaki);
            Console.Read();
        }
    }
