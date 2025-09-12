RS232-to-Keyboard Bridge

Transforme sinais RS232 em digitação de teclado em tempo real.
Automação clássica com confiabilidade moderna.

🎯 Visão Geral

Essa aplicação monitora uma porta serial RS232 (via adaptador USB→RS232) e envia qualquer dado recebido como se fosse digitado no teclado.
Ideal para:

Automação industrial

Testes de equipamentos

POS systems

Simulação de entrada humana a partir de dispositivos seriais

⚡ Funcionalidades

✅ Lista automaticamente todas as portas COM disponíveis

✅ Permite selecionar a porta desejada

✅ Conexão automática e leitura contínua

✅ Envio de dados como entrada de teclado (SendKeys)

✅ Compatível com adaptadores problemáticos usando RJCP.SerialPortStream

✅ Thread separada para leitura contínua sem travar a UI

✅ Fechamento seguro da porta ao sair

🛠️ Tecnologias
Tecnologia	Uso
C# .NET WinForms	Interface gráfica simples
RJCP.SerialPortStream	Comunicação serial robusta
System.IO.Ports	Listagem de portas COM disponíveis
SendKeys	Simulação de teclado
🚀 Como Usar

Clone o projeto:

git clone https://github.com/seuusuario/RS232-to-Keyboard.git


Abra no Visual Studio.

Instale o pacote NuGet:

Install-Package RJCP.SerialPortStream


Compile e execute.

Selecione a porta COM na ComboBox.

Clique Conectar.

Os dados da porta serão enviados como teclado.

⚙️ Configuração e Dicas

Certifique-se de que nenhum outro programa esteja usando a porta COM.

Use drivers oficiais do fabricante para adaptadores USB→RS232.

Teste a porta com PuTTY ou RealTerm antes de usar o app.

Evite caracteres especiais que possam não ser suportados pelo SendKeys.

🌟 Futuro e Melhorias

Reconexão automática caso o adaptador seja desconectado

Configurações de baudrate, paridade e stop bits personalizáveis

Rodar em background como serviço para automação contínua

Interface gráfica melhorada com indicadores de status em tempo real

🤝 Contribuindo

Faça fork do projeto

Crie uma branch com sua feature:

git checkout -b minha-feature


Commit suas alterações:

git commit -m "Minha feature incrível"


Push para a branch:

git push origin minha-feature


Abra um Pull Request e brilhe ✨

⚖️ Licença

MIT License — use, copie e adapte como quiser, mas preserve os créditos.

🖼️ Estrutura de pastas sugerida para portfólio
RS232-to-Keyboard/
RS232-to-Keyboard/
│
├─ src/                  # Código-fonte
├─ docs/                 # GIF, imagens, screenshots
│   ├─ banner.png
│   └─ demo.gif
├─ README.md
└─ LICENSE

