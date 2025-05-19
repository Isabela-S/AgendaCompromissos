interface Compromisso {
  titulo: string;
  data: string;
  hora: string;
  descricao?: string; // pode ou não ter uma descrição
}

const form = document.getElementById('formCompromisso') as HTMLFormElement;
const lista = document.getElementById('listaCompromisso') as HTMLDListElement;

const compromissos: Compromisso[] = [];

form.addEventListener('submit', (event) => {
  event.preventDefault();

  const tituloInput = document.getElementById('titulo') as HTMLInputElement;
  const dataInput = document.getElementById('data') as HTMLInputElement;
  const horaInput = document.getElementById('hora') as HTMLInputElement;
  const descricaoInput = document.getElementById('descricao') as HTMLTextAreaElement;

  // No objeto usa-se vírgulas e não ponto e vírgula
  const novoCompromisso: Compromisso = {
    titulo: tituloInput.value,
    data: dataInput.value,
    hora: horaInput.value,
    descricao: descricaoInput.value
  };

  compromissos.push(novoCompromisso);

  atualizarLista();

  form.reset();
});

function atualizarLista() {
  lista.innerHTML = ""; 

  compromissos.forEach((comp) => {
    const li = document.createElement('li');
    
    li.textContent = `${comp.data} ${comp.hora} - ${comp.titulo} ${comp.descricao ? '- ' + comp.descricao : ''}`;
    lista.appendChild(li);
  });
}

