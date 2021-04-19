import { Zoo } from './zooVrt.js';
import { TipStanista } from './tipStanista.js';

const refreshData = () => {
	document.body.innerHTML = '';
	fetch("https://localhost:44348/TipStanista/").then(p => {
    p.json().then(data => {
        var staniste = data.map(x => new TipStanista(x));
		fetch("https://localhost:44348/ZooVrt/").then(p => {
			p.json().then(data => {
        data.forEach(zoo => {
            const zooVrt = new Zoo(zoo, staniste);
			zooVrt.crtaj(document.body);
        });
    });
});
    });
});
}

refreshData();