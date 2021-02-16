package cr.ac.ucr.teleatlantico.security;

import java.util.Collection;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.AuthorityUtils;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import cr.ac.ucr.teleatlantico.domain.Client;
import cr.ac.ucr.teleatlantico.repository.ClientRepository;


@Service
public class CustomUserDetailService implements UserDetailsService{

	@Autowired
	private ClientRepository repository;

	@Override
	public UserDetails loadUserByUsername(String email) throws UsernameNotFoundException {
		Client client = repository.findByEmail(email);
		if(client == null)
			throw new UsernameNotFoundException("Client not found!");
		return new org.springframework.security.core.userdetails.User(
				client.getEmail(),
				client.getPassword(),
				true,true,true,true,
				getAuthorities()
				);
	}
	
	private static Collection<? extends GrantedAuthority>getAuthorities(){
			//Cambiar si se agregan mas roles
			String[] roles = {"Client"};

			Collection<GrantedAuthority> authorities = AuthorityUtils.createAuthorityList(roles);
			return authorities;
	}
}