import {pronadji} from "./main.js";

export class Dostava{
    constructor(id,naziv,tip,cena,brojAngazovanja,prihod)
    {
        this.id=id;
        this.naziv=naziv;
        this.tip=tip;
        this.cena=cena;
        this.brojAngazovanja=brojAngazovanja;
        this.prihod=prihod;
        this.prosecnaCena=null;
        this.kontejner=null;
    }
    removeAllChildNodes(parent) {
        while (parent.firstChild) {
            parent.removeChild(parent.firstChild);
        }
    }
    crtaj(host)
    {   


        let divKartica = document.createElement("div");
        divKartica.className="divKartica";
        host.appendChild(divKartica);

        let divPodaci = document.createElement("div");
        divPodaci.className="divPodaci";
        divKartica.appendChild(divPodaci);

        let dugmeIsporuci = document.createElement("button");
        dugmeIsporuci.className="dugmeIsporuci";
        dugmeIsporuci.innerHTML="Isporuci";
        dugmeIsporuci.value=this.id;
        divKartica.appendChild(dugmeIsporuci);
        
        
        let divLabeleDostave = document.createElement("div");
        divLabeleDostave.className="divLabeleDostave";
        divPodaci.appendChild(divLabeleDostave);

        let nizP = ["Naziv","Tip","Cena","Prosecna zarada"];

        nizP.forEach((p,index)=>{
            let l = document.createElement("label");
            l.innerHTML=p;
            divLabeleDostave.appendChild(l);
        })
         
        let nizLabela=divLabeleDostave.querySelectorAll("label");
        nizLabela[0].innerHTML=nizLabela[0].innerHTML +" "+ this.naziv;
        nizLabela[1].innerHTML=nizLabela[1].innerHTML +" "+ this.tip;
        nizLabela[2].innerHTML=nizLabela[2].innerHTML +" "+ this.cena;
        nizLabela[3].innerHTML=nizLabela[3].innerHTML +" "+ this.prihod/this.brojAngazovanja;

        dugmeIsporuci.addEventListener("click",()=>this.klikni())  
        



    }
    klikni(){
        
      fetch("https://localhost:5001/Ispit/IsporuciDostavu/"+this.id , {method:"PUT"})
      .then(pronadji())




    }
}