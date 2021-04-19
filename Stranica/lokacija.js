import { TipStanista } from "./tipStanista.js";

export class Lokacija {
	constructor(id, x, y, vrsta, zbir, maxZbir, staniste){
		this.id = id;
		this.x = x;
        this.y = y;
		this.vrsta = vrsta;
		this.zbir = zbir;
        this.maxZbir = maxZbir;
		if(staniste){
			this.staniste = new TipStanista(staniste);
		}
		else{
			this.staniste = staniste
		}
		this.kontejner = null;
		this.deleteClick = false;
	}
	
	izmeni(id, vrsta, kolicina, staniste) {
		this.id = id;
		this.vrsta = vrsta;
		this.zbir += kolicina;
		this.staniste = staniste;
		this.crtajLokaciju();
	}
	
	crtaj(host) {
        this.kontejner = document.createElement("div");
		this.kontejner.onclick = this.deleteFunc;
		this.kontejner.className = "lok";
		
		if(this.deleteClick){
			
		}
		else{
		this.crtajLokaciju();
		}
				
        host.appendChild(this.kontejner);
    }
	
	crtajPotvrdu(host){
		let glavni = document.createElement("div");
		let btnDiv = document.createElement("div");
		var labela = document.createElement("label");
		labela.innerHTML = "Da li zelite da ispraznite staniste?";
		
		var yesBtn = document.createElement("button");
		yesBtn.innerHTML = "Da";
		yesBtn.onclick = this.yesClickHandle;
		
		var noBtn = document.createElement("button");
		noBtn.innerHTML = "Ne";
		noBtn.onclick = this.noClickHandle;
		
		glavni.appendChild(labela);
		btnDiv.appendChild(yesBtn);
		btnDiv.appendChild(noBtn);
		glavni.appendChild(btnDiv);
		
		this.kontejner.firstChild.remove();
		this.kontejner.appendChild(glavni);
	}
	
	deleteFunc = (ev) => {
			if(!this.deleteClick && this.zbir != 0){
				this.deleteClick = true;
				this.crtajPotvrdu();
			} 
        }
		
	noClickHandle = (ev) => {
		ev.stopPropagation();
		this.deleteClick = false;
		this.crtajLokaciju();
	}
	
	yesClickHandle = (ev) => {
		ev.stopPropagation();
		fetch("https://localhost:44348/ZooVrt/OcistiLokaciju/" + this.id, {
                method: "DELETE",
                headers: {
                    "Content-Type": "application/json"
                }
            }).then(p => {
                if (p.ok) {
                    this.id = 0;
					this.vrsta = 'Prazno';
					this.zbir = 0;
					this.staniste = null;
					this.deleteClick = false;
					this.crtajLokaciju();
                }
                else {
                    alert("Greška prilikom brisanja.");
                }
            }).catch(p => {
                alert("Greška prilikom brisanja.");
            });
	}
	
	crtajLokaciju(){
		if(this.kontejner.firstChild){
			this.kontejner.firstChild.remove();
		}
        this.kontejner.innerHTML = this.vrsta + ", " + this.zbir;
        this.kontejner.style.backgroundColor = this.staniste ? this.staniste.boja : "grey";
	}
}