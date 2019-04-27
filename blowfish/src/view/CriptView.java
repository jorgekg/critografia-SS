package view;

import java.util.Scanner;

import controllers.FactoryCriptController;
import controllers.ModeController;

public class CriptView {
	
	private final FactoryCriptController cript = new FactoryCriptController();
	
	private final Scanner scanner = new Scanner(System.in);
	
	public CriptView() {
		awaitForMode();
		awaitForMethod();
	}
	
	private void awaitForMode() {
		System.out.println("1 - para ECB");
		System.out.println("2 - para CBC");
		cript.setMode(ModeController.getModeController(scanner.nextInt()));
	}

	private void awaitForMethod() {
		System.out.println("1 - Criptar");
		System.out.println("2 - Decriptar");
		if (scanner.nextInt() == 1) {
			encript();
		} else {
			decript();
		}
	}
	
	private void encript() {
		awaitForText(true);
		if (cript.getMode().equals("CBC") && canInitilizeValue()) {
			awaitForInitValue();
		}
		System.out.println(cript.encript());
	}
	
	private void decript() {
		awaitForText(false);
		if (cript.getMode().equals("CBC") && canInitilizeValue()) {
			awaitForInitValue();
		}
		System.out.println(cript.decript());
	}
	
	private boolean canInitilizeValue() {
		System.out.println("deseja adicionar uma inicialização digite 1");
		return scanner.nextInt() == 1;
	}
	
	private void awaitForInitValue() {
		System.out.println("digite uma inicialização");
		cript.setInitialValue(scanner.next());
	}
	
	private void awaitForText(boolean isSimpleText) {
		if (isSimpleText) {
			System.out.println("Digite o texto simples");
		} else {
			System.out.println("Digite o texto crifrado");
		}
		cript.setText(scanner.next());
	}
}
