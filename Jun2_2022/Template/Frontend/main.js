import{Dostava}from "./Dostava.js";

function crtaj(host){
let divGlavni = document.createElement("div");
divGlavni.className="divGlavni";
host.appendChild(divGlavni);

let divFilter = document.createElement("div");
divFilter.className="divFilter";
divGlavni.appendChild(divFilter);

let divUnos = document.createElement("div");
divUnos.className="divUnos";
divFilter.appendChild(divUnos);

let divDugmePronadji = document.createElement("div");
divDugmePronadji.className="divDugmePronadji";
divFilter.appendChild(divDugmePronadji);

let labeleNiz = ["Zapremina (cm^3)","Tezina (kg)","Datum prijema","Datum dostave","Cena od","Cena do"];

let divZaLabele = document.createElement("div");
divZaLabele.className="divZaLabele";
divUnos.appendChild(divZaLabele);

labeleNiz.forEach(p=>{
   let labelaUnos = document.createElement("label");
   labelaUnos.innerHTML=p;
   divZaLabele.appendChild(labelaUnos);
})

let divZaInput = document.createElement("div");
divZaInput.className = "divZaInput";
divUnos.appendChild(divZaInput);

let ZapreminaInput = document.createElement("input");
ZapreminaInput.className = "ZapreminaInput";
ZapreminaInput.type="number";
divZaInput.appendChild(ZapreminaInput);

let TezinaInput = document.createElement("input");
TezinaInput.className = "TezinaInput";
TezinaInput.type="number";
divZaInput.appendChild(TezinaInput);

let datumPrijemaInput = document.createElement("input");
datumPrijemaInput.className = "datumPrijemaInput";
datumPrijemaInput.type="date";
divZaInput.appendChild(datumPrijemaInput);

let datumDostaveInput = document.createElement("input");
datumDostaveInput.className = "datumDostaveInput";
datumDostaveInput.type="date";
divZaInput.appendChild(datumDostaveInput);

let cenaOdInput = document.createElement("input");
cenaOdInput .className = "cenaOdInput ";
cenaOdInput .type="number";
divZaInput.appendChild(cenaOdInput);

let cenaDoInput = document.createElement("input");
cenaDoInput .className = "cenaDoInput ";
cenaDoInput .type="number";
divZaInput.appendChild(cenaDoInput);

let divZaDostavu = document.createElement("div");
divZaDostavu.className="divZaDostavu";
divGlavni.appendChild(divZaDostavu);

let dugmePronadji = document.createElement("button");
dugmePronadji.className="dugmePronadji";
dugmePronadji.innerHTML="Pronadji";
dugmePronadji.addEventListener("click",()=>pronadji(divZaDostavu))
divDugmePronadji.appendChild(dugmePronadji);



}
function  removeAllChildNodes(parent) {
    while (parent.firstChild) {
        parent.removeChild(parent.firstChild);
    }
}

export function pronadji(){
    
    let divD = document.querySelector(".divZaDostavu");
    let vrednostZapremina = document.querySelector(".ZapreminaInput").value;
    let vrednostTezina = document.querySelector(".TezinaInput").value;
    let vrednostDatPrijema = document.querySelector(".datumPrijemaInput").value;
    let vrednostDatDostave = document.querySelector(".datumDostaveInput").value;
    let vrednostCenaOd = document.querySelector(".cenaOdInput").value;  
    let vrednostCenaDo = document.querySelector(".cenaDoInput").value;

    removeAllChildNodes(divD);

    if(vrednostZapremina===0)
        {
            alert("Unesite vrednost zapremine koja je obavezna");
        }
        if(vrednostTezina===0)
        {
            alert("Unesite vrednost zapremine koja je obavezna");
        }
    
        fetch(`https://localhost:5001/Ispit/PreuzmiDostave/${vrednostCenaOd}/${vrednostCenaDo}`,{method:"PUT",
        headers:{"Content-Type": "application/json"},
        body: JSON.stringify({
            "zapreminaPaketa": vrednostZapremina,
            "tezinaPaketa": vrednostTezina,
           
            "datumPrijema": vrednostDatPrijema,
             "datumDostave": vrednostDatDostave
            })
        }).then(s=>{
            s.json().then(data=>{
                data.forEach(p=>{
                    let dostavaObj = new Dostava (p.id,p.naziv,p.tip,p.cena,p.brojAngazovanja,p.prihod);
                    dostavaObj.crtaj(divD);
                })
            })
       
        })

    

}

crtaj(document.body);