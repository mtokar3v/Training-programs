function zoomImg(img)
{
	document.getElementById('overlay').style.display = 'block';

	let path = img.getAttribute('src');
	let bigImg = document.createElement("img");
	bigImg.setAttribute("src", path);
	bigImg.id = 'big';
	document.body.prepend(bigImg);

	let body = document.getElementsByTagName('body')[0];
	bigImg.style.top = (window.innerHeight - bigImg.height) / 2 + 'px';
	bigImg.style.left = (window.innerWidth - bigImg.width) /2 + 'px';
	}

overlay.onclick = () => {
	document.getElementById('overlay').style.display = 'none';
	document.getElementById('big').remove();
}

let imgs = document.getElementsByTagName('img');
