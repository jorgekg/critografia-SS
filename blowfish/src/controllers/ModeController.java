package controllers;

public class ModeController {

	public static String getModeController(int type) {
		return type == 1 ? "ECB" : "CBC";
	}
	
}
