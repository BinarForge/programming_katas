// Fine, it is not really a cipher. Even though it is called the Caesar Cipher it is still as lame as swapping the letters around.

if(typeof process === 'undefined' || process.argv.length < 3)
	throw 'Bad parameters!';


const one = ['a','b','c','d','e','f','g','h','i','j','k','l','m'];
const two = ['n','o','p','q','r','s','t','u','v','w','x','y','z'];

let input = process.argv[2];
let output = '';

for(let i in input){
	const char = input[i].toLowerCase();

	let index = one.indexOf(char);
	if(index === -1){
		index = two.indexOf(char);

		if(index === -1){
			output += char;
			continue;
		}

		output += one[index];
	}
	else{
		output += two[index];
	}
}

console.log(output);