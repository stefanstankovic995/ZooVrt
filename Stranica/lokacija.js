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
	}
	
	crtaj(host) {
        let glavni = document.createElement("div");
        glavni.className = "lok";
        glavni.innerHTML = this.vrsta + ", " + this.zbir;
        glavni.style.backgroundColor = this.staniste ? this.staniste.boja : "grey";
        host.appendChild(glavni);

    }
}