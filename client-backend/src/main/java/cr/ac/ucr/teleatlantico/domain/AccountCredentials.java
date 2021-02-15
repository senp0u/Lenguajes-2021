package cr.ac.ucr.teleatlantico.domain;

public class AccountCredentials {
	private String email;
	private String password;
	
	public AccountCredentials(String email, String password) {
		this.email = email;
		this.password = password;
	}
	
	public AccountCredentials() {
		this.email = "";
		this.password = "";
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}
	
}
