package cr.ac.ucr.teleatlantico.domain;

import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;

import java.util.Date;
import java.util.HashSet;
import java.util.Set;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.ManyToMany;
import javax.persistence.OneToMany;
import javax.persistence.Table;


@Entity
@Table(name = "Client")
public class Client {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ClientId")
	private int clientId;
	
	@Column(name = "Name", unique = false, nullable = false ,length = 25)
	private String name;
	
	@Column(name = "FirstSurname", unique = false, nullable = false ,length = 20)
	private String firstSurname;
	
	@Column(name = "SecondSurname", unique = false, length = 20)
	private String secondSurname;
	
	@Column(name = "Address", unique = false, nullable = false ,length = 40)
	private String address;
	
	@Column(name = "Phone", unique = false, nullable = false ,length = 15)
	private String phone;
	
	@Column(name = "SecondContact", unique = false, length = 15)
	private String secondContact;
	
	@Column(name = "Email", unique = true, nullable = false ,length = 30)
	private String email;
	
	@Column(name = "Password", unique = false, nullable = false ,length = 100)
	private String password;
	
	@Column(name = "CreateBy", unique = false, nullable = false ,length = 25)
	private String createBy;
	
	@Column(name = "CreateAt", nullable = false ,unique = false)
	private Date createAt;
	
	@Column(name = "ModifyBy", unique = false, length = 25)
	private String modifyBy;
	
	@Column(name = "ModifyAt", unique = false)
	private Date modifyAt;
	
	@OneToMany(targetEntity = Issue.class,fetch = FetchType.LAZY,
			   cascade = CascadeType.ALL)
	@JoinColumn(name = "ClientId", referencedColumnName = "ClientId", nullable = false)
	private Set<Issue> issues = new HashSet<Issue>();
	
	@ManyToMany(targetEntity = Service.class, fetch = FetchType.LAZY, cascade = CascadeType.ALL)
	@JoinTable(name = "ClientService", joinColumns = 
		@JoinColumn(name = "ClientId", referencedColumnName = "ClientId"), inverseJoinColumns = 
		@JoinColumn(name = "ServiceId", referencedColumnName = "ServiceId"))
	private Set<Service> services = new HashSet<Service>();

	public Client(int clientId, String name, String firstSurname, String secondSurname, String address, String phone,
			String secondContact, String email, String password, String createBy, Date createAt, String modifyBy,
			Date modifyAt, Set<Issue> issues, Set<Service> services) {
		this.clientId = clientId;
		this.name = name;
		this.firstSurname = firstSurname;
		this.secondSurname = secondSurname;
		this.address = address;
		this.phone = phone;
		this.secondContact = secondContact;
		this.email = email;
		this.password = password;
		this.createBy = createBy;
		this.createAt = createAt;
		this.modifyBy = modifyBy;
		this.modifyAt = modifyAt;
		this.issues = issues;
		this.services = services;
	}
	
	public Client() {
		this.clientId = 0;
		this.name = "";
		this.firstSurname = "";
		this.secondSurname = "";
		this.address = "";
		this.phone = "";
		this.secondContact = "";
		this.email = "";
		this.password = "";
		this.createBy = "";
		this.createAt = new Date();
		this.modifyBy = "";
		this.modifyAt = new Date();
	}

	public void encryptPassword() {
		PasswordEncoder passwordEncoder = new BCryptPasswordEncoder(10);
		this.password = passwordEncoder.encode(this.password);
	}

	public int getClientId() {
		return clientId;
	}

	public void setClientId(int clientId) {
		this.clientId = clientId;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getFirstSurname() {
		return firstSurname;
	}

	public void setFirstSurname(String firstSurname) {
		this.firstSurname = firstSurname;
	}

	public String getSecondSurname() {
		return secondSurname;
	}

	public void setSecondSurname(String secondSurname) {
		this.secondSurname = secondSurname;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}

	public String getSecondContact() {
		return secondContact;
	}

	public void setSecondContact(String secondContact) {
		this.secondContact = secondContact;
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

	public String getCreateBy() {
		return createBy;
	}

	public void setCreateBy(String createBy) {
		this.createBy = createBy;
	}

	public Date getCreateAt() {
		return createAt;
	}

	public void setCreateAt(Date createAt) {
		this.createAt = createAt;
	}

	public String getModifyBy() {
		return modifyBy;
	}

	public void setModifyBy(String modifyBy) {
		this.modifyBy = modifyBy;
	}

	public Date getModifyAt() {
		return modifyAt;
	}

	public void setModifyAt(Date modifyAt) {
		this.modifyAt = modifyAt;
	}

	public Set<Issue> getIssues() {
		return issues;
	}

	public void setIssues(Set<Issue> issues) {
		this.issues = issues;
	}

	public Set<Service> getServices() {
		return services;
	}

	public void setServices(Set<Service> services) {
		this.services = services;
	}
}
