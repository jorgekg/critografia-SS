package signature;

import java.util.Scanner;

public class App {

	public static void main(String[] args) throws Exception {
		System.out.println("1 - gerar chaves");
		System.out.println("2 - assinar");
		System.out.println("3 - validar assinar recebida");
		Scanner keyboard = new Scanner(System.in);
		int operation = keyboard.nextInt();
		keyboard.close();
		switch (operation) {
		case 1:
			(new GenerationKeys()).Key();
			break;
		case 2:
			(new Signature()).sign();
			break;
		case 3:
		default:
			(new ValidateSignature()).validate();
			break;
		}
	}

}
