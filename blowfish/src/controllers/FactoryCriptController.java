package controllers;

import java.io.UnsupportedEncodingException;
import java.security.NoSuchAlgorithmException;

import javax.crypto.Cipher;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.spec.SecretKeySpec;

public class FactoryCriptController {
	
	private final String strKey = "ABCDE";
	private String text = "";
	private String mode = "ECB";
	private String initialValue = null;
	
	public String encript() {
		String encryptedText = "";
		try {
			encryptedText = new EncriptController(this).encript();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return encryptedText;
	}
	
	public String decript() {
		String decriptText = "";
		try {
			decriptText = new DecriptController(this).decript();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return decriptText;
	}
	
	public SecretKeySpec getKey() throws UnsupportedEncodingException {
		return new SecretKeySpec(getStrKey().getBytes("UTF-8"), "Blowfish");
	}
	
	public Cipher getCipher() throws NoSuchAlgorithmException, NoSuchPaddingException {
		return Cipher.getInstance("Blowfish/" + getMode() + "/PKCS5Padding");
	}
	
	public void transforTextWithInitialValue() {
		text = initialValue + text;
	}
	
	public String getText() {
		return text;
	}
	public void setText(String text) {
		this.text = text;
	}
	public String getMode() {
		return mode;
	}
	public void setMode(String mode) {
		this.mode = mode;
	}
	public String getInitialValue() {
		return initialValue;
	}
	public void setInitialValue(String initialValue) {
		this.initialValue = initialValue;
	}
	public String getStrKey() {
		return strKey;
	}
}
